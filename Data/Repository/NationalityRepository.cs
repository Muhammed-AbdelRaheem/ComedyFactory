//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using Data.Context;
//using Data.IRepository;
//using Data.Service;
//using Domain.Models;
//using JqueryDataTables.ServerSide.AspNetCoreWeb.Infrastructure;
//using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Caching.Memory;

//namespace Data.Repository
//{
//    public class NationalityRepository : INationalityRepository
//    {
//        private readonly ReadDBContext _read;
//        private readonly WriteDbContext _context;
//        private readonly IMapper _mapper;
//        private readonly IMemoryCache _cache;


//        public NationalityRepository(WriteDbContext context, ReadDBContext read, IMapper mapper, IMemoryCache cache)
//        {
//            _context = context;
//            _read = read;
//            _mapper = mapper;
//            _cache = cache;
//        }

//        public async Task<bool> AddAsync(Nationality Nationality)
//        {
//            try
//            {
//                await _context.AddAsync(Nationality);
//                await _context.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception ex)
//            {

//            }
//            return false;
//        }
        
//        public async Task<bool> DeleteAsync(int id)
//        {
//            try
//            {
//                var Nationality =  await _context.Nationality.FirstOrDefaultAsync(e => e.Id == id);
//                if (Nationality != null)
//                {
//                    Nationality.Deleted = true;
//                    _context.Update(Nationality);
//                    await _context.SaveChangesAsync();
//                    return true;
//                }
               
//            }
//            catch (Exception ex)
//            {

//            }
//            return false;
//        }
//        public async Task<SelectList> GetNationalitiesListAsync(int? selectedNationality = null)
//        {
//            var countries =  await _read.Nationality.Where(e => !e.Hidden).ToListAsync();
//            return new SelectList(countries, "Id", "Name", selectedNationality);
//        }

//        public async Task<SelectList> GetNationalitiesArNameListAsync(int? selectedNationality = null)
//        {
//            var countries = await _read.Nationality.Where(e => !e.Hidden).ToListAsync();
//            return new SelectList(countries, "Id", "ArName", selectedNationality);
//        }

//        public async Task<bool> AnyAsync(int NationalityId)
//        {
//            return await _read.Nationality.AnyAsync(e => e.Id == NationalityId);
//        }
        
//        public async Task<IEnumerable<Nationality>> GetAllAsync()
//        {
//            return await _read.Nationality
//                .OrderBy(s => s.DisplayOrder).ThenByDescending(e => e.Id)
//                .ToListAsync();
//        }

   


//        public async Task<int?> GetSaudiArabianIdAsync()
//        {
//            string cacheKey = "SaudiArabianId";

//            if (_cache.TryGetValue(cacheKey, out int? cachedResult))
//            {
//                return cachedResult;
//            }

//            int? result = await _read.Nationality.Where(e => e.Name.ToLower() == "Saudi Arabian".ToLower())
//                .Select(e => e.Id) 
//                .FirstOrDefaultAsync();

//            _cache.Set(cacheKey, result, Config.GetCacheEntryOption());

//            return result;
//        }


//        public async Task<Nationality?> GetAsync(int NationalityId)
//        {
//            return await _read.Nationality.FirstOrDefaultAsync(e => e.Id == NationalityId);
//        }
        
//        public async Task<bool> UpdateAsync(Nationality Nationality)
//        {
//            try
//            {
//                _context.Update(Nationality);
//                await _context.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception ex)
//            {

//            }
//            return false;
//        }
//        public async Task<JqueryDataTablesPagedResults<NationalityDataTable>> GetNationalitiesDataTableAsync(JqueryDataTablesParameters table)
//        {
//            try
//            {
//                var query = _read.Nationality.OrderByDescending(t => t.Id).AsNoTracking();
//                query = query.Where(
//                   e =>
//                   string.IsNullOrEmpty(table.Search.Value) ||
//                   (
//                       e.Id.ToString().Contains(table.Search.Value)
//                       ||
//                       e.Name!.ToLower().Contains(table.Search.Value.ToLower())
//                   )
//               );


//                query = SearchOptionsProcessor<NationalityDataTable, Nationality>.Apply(query, table.Columns);
//                query = SortOptionsProcessor<NationalityDataTable, Nationality>.Apply(query, table);

//                var size = await query.CountAsync();

//                var items = await query
//                    .AsNoTracking()
//                    .Skip(table.Start / table.Length * table.Length)
//                    .Take(table.Length)
//                    .ProjectTo<NationalityDataTable>(_mapper.ConfigurationProvider)
//                    .ToArrayAsync();


//                return new JqueryDataTablesPagedResults<NationalityDataTable>
//                {
//                    Items = items,
//                    TotalSize = size
//                };
//            }
//            catch (Exception ex)
//            {

//            }
//            return new JqueryDataTablesPagedResults<NationalityDataTable>
//            {
//                TotalSize = 0
//            };
//        }

//    }
//}
