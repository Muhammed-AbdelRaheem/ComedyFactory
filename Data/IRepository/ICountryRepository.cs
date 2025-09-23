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
    public interface ICountryRepository
    {
        public Task<bool> AddAsync(Country Country);
        public Task<bool> UpdateAsync(Country Country);
        public Task<Country?> GetAsync(int CountryId);
        public Task<IEnumerable<Country>> GetAllAsync();
        public Task<bool> AnyAsync(int CountryId);
        public Task<bool> DeleteAsync(int CountryId);
        public Task<SelectList> GetCountriesListAsync(int? selectedCountry = null);
        public Task<SelectList> GetCountriesListArNameAsync(int? selectedCountry = null);

        public Task<JqueryDataTablesPagedResults<CountryDataTable>> GetCountiesDataTableAsync(JqueryDataTablesParameters table);

    }
}
