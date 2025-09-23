using Data;
using Data.IRepository;
using Domain.Models.NotificationHandlerVM;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Repository;
using JqueryDataTables.ServerSide.AspNetCoreWeb.ActionResults;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Newtonsoft.Json;
using AutoMapper;
using Data.Service;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MasterController : Controller
    {
         readonly IMasterRepository  _masterRepository;
         readonly IMasterCategoryRepository   _masterCategoryRepository;
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public MasterController(IMediator mediator, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager, IMasterRepository masterRepository, IMapper mapper, IMasterCategoryRepository masterCategoryRepository)
        {
            _mediator = mediator;
            _httpContext = httpContext;
            _userManager = userManager;
            _masterRepository = masterRepository;
            _mapper = mapper;
            _masterCategoryRepository = masterCategoryRepository;
        }

        // GET: CityController
        public async Task<ActionResult> Index()
        {
            return View(new MasterDataTable());
        }

        [HttpPost]
        public async Task<IActionResult> MasterLoadTable([FromBody] JqueryDataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(JqueryDataTablesParameters), JsonConvert.SerializeObject(param));
                var results = await _masterRepository.GetMasterDataTableAsync(param);


                return new JsonResult(new JqueryDataTablesResult<MasterDataTable>
                {
                    Draw = param.Draw,
                    Data = results.Items,
                    RecordsFiltered = results.TotalSize,
                    RecordsTotal = results.TotalSize
                });
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }
        public async Task<IActionResult> MasterExcel()
        {

            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _masterRepository.GetMasterDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));

            return new JqueryDataTablesExcelResult<MasterDataTable>(results.Items, "Masters", "Masters");
        }
        public async Task<IActionResult> MasterPrintTable()
        {
            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _masterRepository.GetMasterDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));


            return PartialView("_MasterPrintTable", results.Items);
        }


        // GET: MasterController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.mastercategory = await _masterCategoryRepository.GetMasterCategorySelectListAsync();

            return View();
        }

        // POST: MasterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterVM   masterVM)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Force UTC Kind before mapping
                    masterVM.CreatedOnUtc = DateTime.SpecifyKind(masterVM.CreatedOnUtc, DateTimeKind.Utc);
                    masterVM.UpdatedOnUtc = DateTime.SpecifyKind(masterVM.UpdatedOnUtc, DateTimeKind.Utc);

                    var result2 = _mapper.Map<Master>(masterVM);

                    var result = await _masterRepository.AddAsync(result2);
                    if (result)
                    {


                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Created Master  {masterVM.EnName} with Id {masterVM.Id}",
                        });
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch
                {
                }

            }

            ViewBag.mastercategory = await _masterCategoryRepository.GetMasterCategorySelectListAsync(masterVM.MasterCategoryId);

            return View(masterVM);

        }

        // GET: MasterController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Master = await _masterRepository.GetAsync(id);
            if (Master == null)
            {
                return NotFound();

            }
            ViewBag.mastercategory = await _masterCategoryRepository.GetMasterCategorySelectListAsync(Master.MasterCategoryId);
            return View(Master);
        }

        // POST: MasterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterVM  master)
        {
            if (id != master.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result2 = _mapper.Map<Master>(master);

                    var result = await _masterRepository.UpdateAsync(result2);
                    if (result)
                    {
                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Update Master  {master.EnName} with Id {master.Id}",
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await IsCityExist(master.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewBag.mastercategory = await _masterCategoryRepository.GetMasterCategorySelectListAsync(master.MasterCategoryId);

            return View(master);
        }


        public async Task<JsonResult> JsonDelete(int? id)
        {
            if (id == null)
            {
                return Json("Failed");

            }
            var result = await _masterRepository.DeleteAsync((int)id);
            if (result)
            {

                _mediator.Publish(new LogAddViewModel()
                {
                    ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                    IpAddress = Config.GetIpAddress(_httpContext),
                    Table = ControllerContext.ActionDescriptor.ControllerName,
                    Action = ControllerContext.ActionDescriptor.ActionName,
                    Details = $"Delete Master with Id {id}",
                });
                return Json("Removed");
            }
            return Json("Failed");
        }

        public async Task<bool> IsCityExist(int id)
        {
            return await _masterRepository.AnyAsync(id);
        }
    }
}
