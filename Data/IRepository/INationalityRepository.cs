//using Domain.Models;
//using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace Data.IRepository
//{
//    public interface INationalityRepository
//    {
//        public Task<bool> AddAsync(Nationality Nationality);
//        public Task<bool> UpdateAsync(Nationality Nationality);
//        public Task<Nationality?> GetAsync(int NationalityId);
//        public Task<IEnumerable<Nationality>> GetAllAsync();
//        public Task<bool> AnyAsync(int NationalityId);
//        public Task<bool> DeleteAsync(int NationalityId);
//        public Task<int?> GetSaudiArabianIdAsync();

//        public Task<SelectList> GetNationalitiesListAsync(int? selectedNationality = null);
//        public Task<SelectList> GetNationalitiesArNameListAsync(int? selectedNationality = null);

//        public Task<JqueryDataTablesPagedResults<NationalityDataTable>> GetNationalitiesDataTableAsync(JqueryDataTablesParameters table);

//    }
//}
