using AutoMapper;
using Data.IRepository;
using Data.Repository;
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

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DesireController : Controller
    {
        readonly IDesireRepository _desireRepository;
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public DesireController(IMediator mediator, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager, IMapper mapper, IDesireRepository desireRepository)
        {
            _mediator = mediator;
            _httpContext = httpContext;
            _userManager = userManager;
            _mapper = mapper;
            _desireRepository = desireRepository;
        }

        // GET: CityController
        public async Task<ActionResult> Index()
        {
            return View(new DesireTableData());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] JqueryDataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(JqueryDataTablesParameters), JsonConvert.SerializeObject(param));
                var results = await _desireRepository.GetDesireDataTableAsync(param);


                return new JsonResult(new JqueryDataTablesResult<DesireTableData>
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

            var results = await _desireRepository.GetDesireDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));

            return new JqueryDataTablesExcelResult<DesireTableData>(results.Items, "Desire", "Desire");
        }
        public async Task<IActionResult> PrintTable()
        {
            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _desireRepository.GetDesireDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));


            return PartialView("_PrintTable", results.Items);
        }


        // GET: CityController/Create
        public async Task<ActionResult> Create()
        {

            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DesireVM masterVM)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result2 = _mapper.Map<Desire>(masterVM);

                    var result = await _desireRepository.AddAsync(result2);
                    if (result)
                    {


                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Created Desire  {masterVM.EnName} with Id {masterVM.Id}",
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
            var Master = await _desireRepository.GetAsync(id);
            if (Master == null)
            {
                return NotFound();

            }
            return View(Master);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DesireVM master)
        {
            if (id != master.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result2 = _mapper.Map<Desire>(master);

                    var result = await _desireRepository.UpdateAsync(result2);
                    if (result)
                    {
                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Update Desire  {master.EnName} with Id {master.Id}",
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
            var result = await _desireRepository.DeleteAsync((int)id);
            if (result)
            {

                _mediator.Publish(new LogAddViewModel()
                {
                    ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                    IpAddress = Config.GetIpAddress(_httpContext),
                    Table = ControllerContext.ActionDescriptor.ControllerName,
                    Action = ControllerContext.ActionDescriptor.ActionName,
                    Details = $"Delete Desire with Id {id}",
                });
                return Json("Removed");
            }
            return Json("Failed");
        }

        public async Task<bool> IsCityExist(int id)
        {
            return await _desireRepository.AnyAsync(id);
        }
    }

}
