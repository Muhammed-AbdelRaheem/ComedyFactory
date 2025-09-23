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
    public class MasterCategoryController : Controller
    {
         readonly IMasterCategoryRepository   _masterCategoryRepository;
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public MasterCategoryController(IMediator mediator, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager , IMapper mapper, IMasterCategoryRepository masterCategoryRepository)
        {
            _mediator = mediator;
            _httpContext = httpContext;
            _userManager = userManager;
            _mapper = mapper;
            _masterCategoryRepository = masterCategoryRepository;
        }

        // GET: CityController
        public async Task<ActionResult> Index()
        {
            return View(new MasterCategoryTableData());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] JqueryDataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(JqueryDataTablesParameters), JsonConvert.SerializeObject(param));
                var results = await _masterCategoryRepository.GetMasterCategoryDataTableAsync(param);


                return new JsonResult(new JqueryDataTablesResult<MasterCategoryTableData>
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
        public async Task<IActionResult> Excel()
        {

            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _masterCategoryRepository.GetMasterCategoryDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));

            return new JqueryDataTablesExcelResult<MasterCategoryTableData>(results.Items, "MasterCategory", "MasterCategory");
        }
        public async Task<IActionResult> PrintTable()
        {
            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _masterCategoryRepository.GetMasterCategoryDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));


            return PartialView("_MasterCategoryPrintTable", results.Items);
        }


        // GET: CityController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterCategoryVM   masterVM)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result2 = _mapper.Map<MasterCategory>(masterVM);

                    var result = await _masterCategoryRepository.AddAsync(result2);
                    if (result)
                    {


                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Created MasterCategory  {masterVM.EnName} with Id {masterVM.Id}",
                        });
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch
                {
                }

            }


            return View(masterVM);

        }

        // GET: CityController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var Master = await _masterCategoryRepository.GetAsync(id);
            if (Master == null)
            {
                return NotFound();

            }

            return View(Master);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MasterCategoryVM master)
        {
            if (id != master.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result2 = _mapper.Map<MasterCategory>(master);

                    var result = await _masterCategoryRepository.UpdateAsync(result2);
                    if (result)
                    {
                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Update MasterCategory  {master.EnName} with Id {master.Id}",
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

            return View(master);
        }


        public async Task<JsonResult> JsonDelete(int? id)
        {
            if (id == null)
            {
                return Json("Failed");

            }
            var result = await _masterCategoryRepository.DeleteAsync((int)id);
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
            return await _masterCategoryRepository.AnyAsync(id);
        }
    }
}
