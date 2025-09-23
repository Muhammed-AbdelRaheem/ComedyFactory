using Data.IRepository;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebUi.Controllers
{
    public class AboutController : Controller
    {
        private readonly IBlockRepository _BlockRepository;

        private readonly IMasterCategoryRepository  _masterCategoryRepository;
        private readonly IMasterRepository  _masterRepository;

        public AboutController(IBlockRepository BlockRepository, IMasterRepository masterRepository, IMasterCategoryRepository masterCategoryRepository)
        {
            _BlockRepository = BlockRepository;
            _masterRepository = masterRepository;
            _masterCategoryRepository = masterCategoryRepository;
        }


        public async Task<IActionResult> Index( )
        {
 
            var masters = await _masterRepository.GetAllAsync();
            ViewData["masters"] = masters;

            var mastersCategories = await _masterCategoryRepository.GetAllAsync();
            ViewData["mastersCategories"] = mastersCategories;
            return View();

        }
    }
}
