using Domain.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface ICityRepository
    {
        public Task<bool> AddAsync(City City);
        public Task<bool> UpdateAsync(City City);
        public Task<City?> GetAsync(int CityId);
        public Task<IEnumerable<City>> GetAllAsync();
        public Task<bool> AnyAsync(int CityId);
        public Task<bool> DeleteAsync(int CityId);

        public Task<SelectList> GetCitiesListAsync(int? selectedCity = null);
        public Task<SelectList> GetArCitiesListAsync(int? selectedCity = null);
        public Task<JqueryDataTablesPagedResults<CityDataTable>> GetCitiesDataTableAsync(JqueryDataTablesParameters table);

    }
}
