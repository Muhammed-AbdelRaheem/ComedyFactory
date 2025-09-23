using AutoMapper;
using Data.IRepository;
using Data.Service;
using Domain.Models;
using Domain.Models.NotificationHandlerVM;
using JqueryDataTables.ServerSide.AspNetCoreWeb.ActionResults;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActivityController : Controller
    {
        readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public ActivityController(IMediator mediator, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager, IMapper mapper, IActivityRepository activityRepository)
        {
            _mediator = mediator;
            _httpContext = httpContext;
            _userManager = userManager;
            _mapper = mapper;
            _activityRepository = activityRepository;
        }

        // GET: CityController
        public async Task<ActionResult> Index()
        {
            return View(new ActivityTableData());
        }

        [HttpPost]
        public async Task<IActionResult> ActivityLoadTable([FromBody] JqueryDataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(JqueryDataTablesParameters), JsonConvert.SerializeObject(param));
                var results = await _activityRepository.GetMasterDataTableAsync(param);


                return new JsonResult(new JqueryDataTablesResult<ActivityTableData>
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

            var results = await _activityRepository.GetMasterDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));

            return new JqueryDataTablesExcelResult<ActivityTableData>(results.Items, "Activity", "Activity");
        }
        public async Task<IActionResult> MasterPrintTable()
        {
            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _activityRepository.GetMasterDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));


            return PartialView("_ActivityPrintTable", results.Items);
        }


        // GET: CityController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ActivityVM masterVM)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    // Force UTC Kind before mapping
                    masterVM.CreatedOnUtc = DateTime.SpecifyKind(masterVM.CreatedOnUtc, DateTimeKind.Utc);
                    masterVM.UpdatedOnUtc = DateTime.SpecifyKind(masterVM.UpdatedOnUtc, DateTimeKind.Utc);

                    var result2 = _mapper.Map<Activities>(masterVM);

                    var result = await _activityRepository.AddAsync(result2);
                    if (result)
                    {


                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Created Activities  {masterVM.EnName} with Id {masterVM.Id}",
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
            var Master = await _activityRepository.GetAsync(id);
            if (Master == null)
            {
                return NotFound();

            }

            return View(Master);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ActivityVM master)
        {
            if (id != master.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result2 = _mapper.Map<Activities>(master);

                    var result = await _activityRepository.UpdateAsync(result2);
                    if (result)
                    {
                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Update Activities  {master.EnName} with Id {master.Id}",
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await IsExist(master.Id)))
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
            var result = await _activityRepository.DeleteAsync((int)id);
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

        public async Task<bool> IsExist(int id)
        {
            return await _activityRepository.AnyAsync(id);
        }
    }
}
