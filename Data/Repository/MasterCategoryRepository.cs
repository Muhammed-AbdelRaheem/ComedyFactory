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
    public class MasterCategoryRepository : IMasterCategoryRepository
    {
        private readonly ReadDBContext _read;
        private readonly WriteDbContext _context;
        private readonly IMapper _mapper;

        public MasterCategoryRepository(WriteDbContext context, ReadDBContext read, IMapper mapper)
        {
            _context = context;
            _read = read;
            _mapper = mapper;
        }



        public async Task<SelectList?> GetMasterCategorySelectListAsync(int? selected = null)
        {
            var zones = await _read.MasterCategories.Where(e => !e.Hidden && !e.Deleted).Select(e => new { e.Id, e.EnName }).ToListAsync();

            return new SelectList(zones.Select(e => new
            {
                e.Id,
                e.EnName,

            }), "Id", "EnName", selected);
        }

        public async Task<bool> AddAsync(MasterCategory master)
        {
            try
            {
                await _context.AddAsync(master);
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
                var master = await _context.MasterCategories.FirstOrDefaultAsync(e => e.Id == id);
                if (master != null)
                {
                    master.Deleted = true;
                    _context.Update(master);
                    await _context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception ex)
            {

            }
            return false;
        }


        public async Task<bool> AnyAsync(int Id)
        {
            return await _read.MasterCategories.AnyAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<MasterCategory>> GetAllAsync()
        {
            return await _read.MasterCategories.Where(e => !e.Deleted && !e.Hidden)
                .OrderBy(s => s.DisplayOrder).ThenByDescending(e => e.Id)
                .ToListAsync();
        }

        public async Task<MasterCategoryVM?> GetAsync(int id)
        {
            return await _read.MasterCategories.Where(s => s.Id == id)
                .ProjectTo<MasterCategoryVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        }

        public async Task<bool> UpdateAsync(MasterCategory master)
        {
            try
            {
                _context.Update(master);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public async Task<JqueryDataTablesPagedResults<MasterCategoryTableData>> GetMasterCategoryDataTableAsync(JqueryDataTablesParameters table)
        {
            try
            {



                var query = _read.MasterCategories.Where(e => !e.Deleted).OrderByDescending(t => t.Id).AsNoTracking();



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


                query = SearchOptionsProcessor<MasterCategoryTableData, MasterCategory>.Apply(query, table.Columns);
                query = SortOptionsProcessor<MasterCategoryTableData, MasterCategory>.Apply(query, table);

                var size = await query.CountAsync();

                var items = await query
                    .AsNoTracking()
                    .Skip(table.Start / table.Length * table.Length)
                    .Take(table.Length)
                    .ProjectTo<MasterCategoryTableData>(_mapper.ConfigurationProvider)
                    .ToArrayAsync();


                return new JqueryDataTablesPagedResults<MasterCategoryTableData>
                {
                    Items = items,
                    TotalSize = size
                };
            }
            catch (Exception ex)
            {

            }
            return new JqueryDataTablesPagedResults<MasterCategoryTableData>
            {
                TotalSize = 0
            };
        }

    }

}
