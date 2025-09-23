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
    public interface IDesireRepository
    {
        public Task<bool> AddAsync(Desire master);
        public Task<bool> UpdateAsync(Desire master);
        public Task<DesireVM?> GetAsync(int Id);
        public Task<IEnumerable<Desire>> GetAllAsync();
        public Task<bool> AnyAsync(int Id);
        public Task<bool> DeleteAsync(int Id);

        public Task<JqueryDataTablesPagedResults<DesireTableData>> GetDesireDataTableAsync(JqueryDataTablesParameters table);

        public Task<SelectList?> GetDesireSelectListAsync(int? selected = null);

        public Task<SelectList?> GetArDesireSelectListAsync(int? selected = null);

    }
}
