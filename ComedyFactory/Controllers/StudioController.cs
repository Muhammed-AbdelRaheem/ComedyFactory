//using Data.IRepository;
//using Domain.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace WebUi.Controllers
//{
//    public class StudioController : Controller
//    {
//        private readonly IBlockRepository _BlockRepository;

//        private readonly IAboutUsMediaRepository _aboutUsGallery;

//        public StudioController(  IAboutUsMediaRepository aboutUsGallery)
//        {
//            _aboutUsGallery = aboutUsGallery;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var AbboutUsGallery = await _aboutUsGallery.GetAllGallery();

//            ViewData["MediaGallery"] = AbboutUsGallery;

//            return View();
//        }
//    }
//}
