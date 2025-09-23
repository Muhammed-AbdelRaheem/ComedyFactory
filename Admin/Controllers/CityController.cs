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

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CitiesController : Controller
    {
        readonly ICityRepository _CityRepository;
        readonly ICountryRepository _CountryRepository;

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public CitiesController(IMediator mediator, ICityRepository CityRepository, ICountryRepository countryRepository, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _CityRepository = CityRepository;
            _CountryRepository = countryRepository;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // GET: CityController
        public async Task<ActionResult> Index()
        {
            return View(new CityDataTable());
        }

        [HttpPost]
        public async Task<IActionResult> CitiesLoadTable([FromBody] JqueryDataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(JqueryDataTablesParameters), JsonConvert.SerializeObject(param));
                var results = await _CityRepository.GetCitiesDataTableAsync(param);


                return new JsonResult(new JqueryDataTablesResult<CityDataTable>
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
        public async Task<IActionResult> CitiesExcel()
        {

            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _CityRepository.GetCitiesDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));

            return new JqueryDataTablesExcelResult<CityDataTable>(results.Items, "Cities", "Cities");
        }
        public async Task<IActionResult> CitiesPrintTable()
        {
            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _CityRepository.GetCitiesDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param));


            return PartialView("_CitiesPrintTable", results.Items);
        }


        // GET: CityController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(City City)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Force UTC Kind before mapping
                    City.CreatedOnUtc = DateTime.SpecifyKind(City.CreatedOnUtc, DateTimeKind.Utc);
                    City.UpdatedOnUtc = DateTime.SpecifyKind(City.UpdatedOnUtc, DateTimeKind.Utc);

                    var result = await _CityRepository.AddAsync(City);
                    if (result)
                    {


                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Created City  {City.EnName} with Id {City.Id}",
                        });
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch
                {
                }

            }
            //ViewData["Countries"] = await _CountryRepository.GetCountriesListAsync(City.CountryId);


            return View(City);

        }

        // GET: CityController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var City = await _CityRepository.GetAsync(id);
            if (City == null)
            {
                return NotFound();

            }
            //ViewData["Countries"] = await _CountryRepository.GetCountriesListAsync(City.CountryId);

            return View(City);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, City City)
        {
            if (id != City.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Force UTC Kind before mapping
                    City.CreatedOnUtc = DateTime.SpecifyKind(City.CreatedOnUtc, DateTimeKind.Utc);
                    City.UpdatedOnUtc = DateTime.SpecifyKind(City.UpdatedOnUtc, DateTimeKind.Utc);
                    var result = await _CityRepository.UpdateAsync(City);
                    if (result)
                    {
                        _mediator.Publish(new LogAddViewModel()
                        {
                            ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                            IpAddress = Config.GetIpAddress(_httpContext),
                            Table = ControllerContext.ActionDescriptor.ControllerName,
                            Action = ControllerContext.ActionDescriptor.ActionName,
                            Details = $"Update City  {City.EnName} with Id {City.Id}",
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await IsCityExist(City.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            //ViewData["Countries"] = await _CountryRepository.GetCountriesListAsync(City.CountryId);
            return View(City);
        }


        public async Task<JsonResult> JsonDelete(int? id)
        {
            if (id == null)
            {
                return Json("Failed");

            }
            var result = await _CityRepository.DeleteAsync((int)id);
            if (result)
            {

                _mediator.Publish(new LogAddViewModel()
                {
                    ApplicationUserId = Config.GetUserId(_httpContext, _userManager),
                    IpAddress = Config.GetIpAddress(_httpContext),
                    Table = ControllerContext.ActionDescriptor.ControllerName,
                    Action = ControllerContext.ActionDescriptor.ActionName,
                    Details = $"Delete City with Id {id}",
                });
                return Json("Removed");
            }
            return Json("Failed");
        }

        public async Task<bool> IsCityExist(int id)
        {
            return await _CityRepository.AnyAsync(id);
        }
    }

}
