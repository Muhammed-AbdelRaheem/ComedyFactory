

using ComedyFactory.Models;
using Data.IRepository;
using Data.Repository;
using Domain.Models;
using Domain.Models.ViewModel;
using IoC.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using reCAPTCHA.AspNetCore;

namespace WebUi.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IConfiguration _configuration;
        private readonly IMasterRepository _masterRepository;
        private readonly IMasterCategoryRepository _masterCategoryRepository;
        private readonly IActivityRepository _ActivityRepository;
        private readonly IBlockRepository _blockRepository;
        private readonly IRecaptchaService _recaptchaService;
        private readonly IPersonalDataRepository _personalDataRepository;


        public HomeController(IPersonalDataRepository personalDataRepository, IRecaptchaService recaptchaService,
                            IConfiguration configuration, IStringLocalizer<SharedResource> localizer,
                            IMasterRepository masterRepository, IMasterCategoryRepository masterCategoryRepository,
                            IActivityRepository activityRepository,IBlockRepository blockRepository)
        {

            _personalDataRepository = personalDataRepository;
            _recaptchaService = recaptchaService;
            _configuration = configuration;
            _localizer = localizer;
            _masterRepository = masterRepository;
            _masterCategoryRepository = masterCategoryRepository;
            _ActivityRepository = activityRepository;
            _blockRepository = blockRepository;
        }

   
        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(Index), new { language = _configuration["DefaultLanguage"] });
        }

        public async Task<IActionResult> Register(string language = "en")
        {


            ViewData["Title"] = _localizer["Home Page"];
            if (language == "ar")
                return View("Register.ar");

            return View("Register");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactForm(string? language, PersonalDataVM personalDataVM)
        {
            
                   
            if (ModelState.IsValid)
            {
                

                try
                {
                    var result = await _personalDataRepository.AddData(language, personalDataVM);
                    if (result)
                        return RedirectToAction("Index", "Success", new { language });
                }
                catch (Exception ex)
                {
                    // log ex.Message
                    return Content("Error: " + ex.Message);
                }

            }
            return View("Register", personalDataVM);
        }

        public async Task<IActionResult> Index(string language = "en")
        {
            var masters = await _masterRepository.GetAllAsync();
            var mastersCategories = await _masterCategoryRepository.GetAllAsync();
            var activities = await _ActivityRepository.GetAllAsync();

            var block = await _blockRepository.GetBlockshomepage(BlockType.HomePage);

            var vm = new HomeIndexViewModel
            {
                Masters = masters.ToList(),
                MastersCategories = mastersCategories.ToList(),
                Activities = activities.ToList(),
                HomePageBlock = block
            };
       
            return LocalizedView("Index", language, vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return base.View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IActionResult LocalizedView(string viewName, string? language = null, object? model = null)
        {
            language ??= _configuration["DefaultLanguage"];

            var localizedViewName = string.Equals(language, "ar", StringComparison.OrdinalIgnoreCase)
                ? $"{viewName}.ar"
                : viewName;

            return View(localizedViewName, model);
        }
    }
}
