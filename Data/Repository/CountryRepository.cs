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
    public class CountryRepository : ICountryRepository
    {
        private readonly ReadDBContext _read;
        private readonly WriteDbContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(WriteDbContext context, ReadDBContext read, IMapper mapper)
        {
            _context = context;
            _read = read;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(Country Country)
        {
            try
            {
                await _context.AddAsync(Country);
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
                var Country = await _context.Country.FirstOrDefaultAsync(e => e.Id == id);
                if (Country != null)
                {
                    Country.Deleted = true;
                    _context.Update(Country);
                    await _context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public async Task<SelectList> GetCountriesListAsync(int? selectedCountry = null)
        {
            var countries = await _read.Country.Where(e => !e.Hidden).ToListAsync();
            return new SelectList(countries, "Id", "EnName", selectedCountry);
        }

        public async Task<SelectList> GetCountriesListArNameAsync(int? selectedCountry)
        {
            var countries = await _read.Country.Where(e => !e.Hidden).ToListAsync();
            return new SelectList(countries, "Id", "ArName", selectedCountry);
        }


        public async Task<bool> AnyAsync(int CountryId)
        {
            return await _read.Country.AnyAsync(e => e.Id == CountryId);
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _read.Country
                .OrderBy(s => s.DisplayOrder).ThenByDescending(e => e.Id)
                .ToListAsync();
        }

        public async Task<Country?> GetAsync(int CountryId)
        {
            return await _read.Country.FirstOrDefaultAsync(e => e.Id == CountryId);
        }

        public async Task<bool> UpdateAsync(Country Country)
        {
            try
            {
                _context.Update(Country);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<JqueryDataTablesPagedResults<CountryDataTable>> GetCountiesDataTableAsync(JqueryDataTablesParameters table)
        {
            try
            {



                var query = _read.Country.OrderByDescending(t => t.Id).AsNoTracking();



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


                query = SearchOptionsProcessor<CountryDataTable, Country>.Apply(query, table.Columns);
                query = SortOptionsProcessor<CountryDataTable, Country>.Apply(query, table);

                var size = await query.CountAsync();

                var items = await query
                    .AsNoTracking()
                    .Skip(table.Start / table.Length * table.Length)
                    .Take(table.Length)
                    .ProjectTo<CountryDataTable>(_mapper.ConfigurationProvider)
                    .ToArrayAsync();


                return new JqueryDataTablesPagedResults<CountryDataTable>
                {
                    Items = items,
                    TotalSize = size
                };
            }
            catch (Exception ex)
            {

            }
            return new JqueryDataTablesPagedResults<CountryDataTable>
            {
                TotalSize = 0
            };
        }
    }

}
