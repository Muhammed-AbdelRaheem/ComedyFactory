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
    public interface IMasterCategoryRepository
    {
        public Task<bool> AddAsync(MasterCategory master);
        public Task<bool> UpdateAsync(MasterCategory master);
        public Task<MasterCategoryVM?> GetAsync(int Id);
        public Task<IEnumerable<MasterCategory>> GetAllAsync();
        public Task<bool> AnyAsync(int Id);
        public Task<bool> DeleteAsync(int Id);

        public Task<JqueryDataTablesPagedResults<MasterCategoryTableData>> GetMasterCategoryDataTableAsync(JqueryDataTablesParameters table);


        public Task<SelectList?> GetMasterCategorySelectListAsync(int? selected = null);


    }
}
