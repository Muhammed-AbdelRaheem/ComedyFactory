using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Context;
using Data.IRepository;
using Domain.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Infrastructure;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ReadDBContext _read;
        private readonly WriteDbContext _context;
        private readonly IMapper _mapper;

        public ActivityRepository(WriteDbContext context, ReadDBContext read, IMapper mapper)
        {
            _context = context;
            _read = read;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(Activities master)
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
                var master = await _context.Activities.FirstOrDefaultAsync(e => e.Id == id);
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
            return await _read.Activities.AnyAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Activities>> GetAllAsync()
        {
            return await _read.Activities.Where(e => !e.Deleted && !e.Hidden)
                .OrderBy(s => s.DisplayOrder).ThenByDescending(e => e.Id)
                .ToListAsync();
        }

        public async Task<ActivityVM?> GetAsync(int id)
        {
            return await _read.Activities.Where(s => s.Id == id)
                .ProjectTo<ActivityVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        }

        public async Task<bool> UpdateAsync(Activities master)
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
        public async Task<JqueryDataTablesPagedResults<ActivityTableData>> GetMasterDataTableAsync(JqueryDataTablesParameters table)
        {
            try
            {



                var query = _read.Activities.Where(e => !e.Deleted).OrderByDescending(t => t.Id).AsNoTracking();



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


                query = SearchOptionsProcessor<ActivityTableData, Activities>.Apply(query, table.Columns);
                query = SortOptionsProcessor<ActivityTableData, Activities>.Apply(query, table);

                var size = await query.CountAsync();

                var items = await query
                    .AsNoTracking()
                    .Skip(table.Start / table.Length * table.Length)
                    .Take(table.Length)
                    .ProjectTo<ActivityTableData>(_mapper.ConfigurationProvider)
                    .ToArrayAsync();


                return new JqueryDataTablesPagedResults<ActivityTableData>
                {
                    Items = items,
                    TotalSize = size
                };
            }
            catch (Exception ex)
            {

            }
            return new JqueryDataTablesPagedResults<ActivityTableData>
            {
                TotalSize = 0
            };
        }

    }

}
