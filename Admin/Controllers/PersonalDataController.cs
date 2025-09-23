using Data.IRepository;
using Domain.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.ActionResults;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Admin.Controllers
{
    //[Authorize(Roles = "Admin")]

    public class PersonalDataController : Controller
    {
        private readonly IPersonalDataRepository _personalDataRepository;

        public PersonalDataController(IPersonalDataRepository personalDataRepository)
        {
            _personalDataRepository = personalDataRepository;
        }
        public IActionResult Index()
        {
            return View(new PersonalDataTable());
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] JqueryDataTablesParameters param, FilterVM filterVM)
        {
            try
            {
                HttpContext.Session.SetString(nameof(JqueryDataTablesParameters), JsonConvert.SerializeObject(param));
                var results = await _personalDataRepository.GetPersonalDataTableAsync(param, filterVM);

                return new JsonResult(new JqueryDataTablesResult<PersonalDataTable>
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
        public async Task<IActionResult> PersonalExcel(FilterVM filterVM)
        {

            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _personalDataRepository.GetPersonalDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param), filterVM);

            return new JqueryDataTablesExcelResult<PersonalDataTable>(results.Items, "PersonalData", "PersonalData");
        }
        public async Task<IActionResult> PersonalPrintTable(FilterVM filterVM)
        {
            var param = HttpContext.Session.GetString(nameof(JqueryDataTablesParameters));

            var results = await _personalDataRepository.GetPersonalDataTableAsync(JsonConvert.DeserializeObject<JqueryDataTablesParameters>(param), filterVM);


            return PartialView("_RegistrationsPrintTable", results.Items);
        }


    }
}
