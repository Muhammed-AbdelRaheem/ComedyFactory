using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Context;
using Data.IRepository;
using Domain.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Infrastructure;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ReadDBContext _read;
        private readonly WriteDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(WriteDbContext context, ReadDBContext read, IMapper mapper)
        {
            _context = context;
            _read = read;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(City City)
        {
            try
            {
                await _context.AddAsync(City);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var City = await _context.City.FirstOrDefaultAsync(e => e.Id == id);
                if (City != null)
                {
                    City.Deleted = true;
                    _context.Update(City);
                    await _context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public async Task<SelectList> GetCitiesListAsync(int? selectedCity = null)
        {
            var City = await _read.City.Where(e => !e.Hidden && !e.Deleted).ToListAsync();
            return new SelectList(City, "Id", "EnName", selectedCity);
        }
        public async Task<SelectList> GetArCitiesListAsync(int? selectedCity = null)
        {
            var City = await _read.City.Where(e => !e.Hidden && !e.Deleted).ToListAsync();
            return new SelectList(City, "Id", "ArName", selectedCity);
        }

        public async Task<bool> AnyAsync(int CityId)
        {
            return await _read.City.AnyAsync(e => e.Id == CityId);
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _read.City
                .OrderBy(s => s.DisplayOrder).ThenByDescending(e => e.Id)
                .Include(e => e.Country)
                .ToListAsync();
        }

        public async Task<City?> GetAsync(int CityId)
        {
            return await _read.City.FirstOrDefaultAsync(e => e.Id == CityId);
        }

        public async Task<bool> UpdateAsync(City City)
        {
            try
            {
                _context.Update(City);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public async Task<JqueryDataTablesPagedResults<CityDataTable>> GetCitiesDataTableAsync(JqueryDataTablesParameters table)
        {
            try
            {



                var query = _read.City.OrderByDescending(t => t.Id).AsNoTracking();



                query = query.Where(
                   e =>
                   string.IsNullOrEmpty(table.Search.Value) ||
                   (
                       e.Id.ToString().Contains(table.Search.Value)
                       ||
                       e.ArName!.ToLower().Contains(table.Search.Value.ToLower())
                       ||
                       e.EnName!.ToLower().Contains(table.Search.Value.ToLower())


                   )
               );


                query = SearchOptionsProcessor<CityDataTable, City>.Apply(query, table.Columns);
                query = SortOptionsProcessor<CityDataTable, City>.Apply(query, table);

                var size = await query.CountAsync();

                var items = await query
                    .AsNoTracking()
                    .Skip(table.Start / table.Length * table.Length)
                    .Take(table.Length)
                    .ProjectTo<CityDataTable>(_mapper.ConfigurationProvider)
                    .ToArrayAsync();


                return new JqueryDataTablesPagedResults<CityDataTable>
                {
                    Items = items,
                    TotalSize = size
                };
            }
            catch (Exception ex)
            {

            }
            return new JqueryDataTablesPagedResults<CityDataTable>
            {
                TotalSize = 0
            };
        }

    }

}
