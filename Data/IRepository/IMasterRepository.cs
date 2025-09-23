using Domain.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IMasterRepository
    {
        public Task<bool> AddAsync(Master master);
        public Task<bool> UpdateAsync(Master master);
        public Task<MasterVM?> GetAsync(int Id);
        public Task<IEnumerable<Master>> GetAllAsync();
        public Task<bool> AnyAsync(int Id);
        public Task<bool> DeleteAsync(int Id);

        public Task<JqueryDataTablesPagedResults<MasterDataTable>> GetMasterDataTableAsync(JqueryDataTablesParameters table);

    }
}
