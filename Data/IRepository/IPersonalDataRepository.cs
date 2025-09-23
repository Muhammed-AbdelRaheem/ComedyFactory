using Domain.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IPersonalDataRepository
    {
        public Task<IEnumerable<PersonalData>> GetAllAsync(bool hidden = false);
        public Task<PersonalData?> GetPersonalDataAsync(int id, bool hidden = false);

        public Task<bool> AddData(string? language, PersonalDataVM personalDataVM);
        public Task<bool> DeleteAsync(int id);
        public Task<JqueryDataTablesPagedResults<PersonalDataTable>> GetPersonalDataTableAsync(JqueryDataTablesParameters table, FilterVM filterVM);

        public Task<bool> AddAsync(PersonalData personalData);


    }
}
