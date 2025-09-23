using Domain.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IActivityRepository
    {
        public Task<bool> AddAsync(Activities master);
        public Task<bool> UpdateAsync(Activities master);
        public Task<ActivityVM?> GetAsync(int Id);
        public Task<IEnumerable<Activities>> GetAllAsync();
        public Task<bool> AnyAsync(int Id);
        public Task<bool> DeleteAsync(int Id);

        public Task<JqueryDataTablesPagedResults<ActivityTableData>> GetMasterDataTableAsync(JqueryDataTablesParameters table);

    }
}
