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
    public class MasterRepository : IMasterRepository
    {
        private readonly ReadDBContext _read;
        private readonly WriteDbContext _context;
        private readonly IMapper _mapper;

        public MasterRepository(WriteDbContext context, ReadDBContext read, IMapper mapper)
        {
            _context = context;
            _read = read;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(Master master)
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
                var master = await _context.Masters.FirstOrDefaultAsync(e => e.Id == id);
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
            return await _read.Masters.AnyAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Master>> GetAllAsync()
        {
            return await _read.Masters.Include(e => e.MasterCategory).Where(E => !E.Deleted && !E.Hidden)
                .OrderBy(s => s.DisplayOrder).ThenByDescending(e => e.Id)
                .ToListAsync();
        }

        public async Task<MasterVM?> GetAsync(int id)
        {
            return await _read.Masters.Where(s => s.Id == id)
                .ProjectTo<MasterVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        }

        public async Task<bool> UpdateAsync(Master master)
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
        public async Task<JqueryDataTablesPagedResults<MasterDataTable>> GetMasterDataTableAsync(JqueryDataTablesParameters table)
        {
            try
            {



                var query = _read.Masters.Where(e => !e.Deleted).OrderByDescending(t => t.Id).AsNoTracking();



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


                query = SearchOptionsProcessor<MasterDataTable, Master>.Apply(query, table.Columns);
                query = SortOptionsProcessor<MasterDataTable, Master>.Apply(query, table);

                var size = await query.CountAsync();

                var items = await query
                    .AsNoTracking()
                    .Skip(table.Start / table.Length * table.Length)
                    .Take(table.Length)
                    .ProjectTo<MasterDataTable>(_mapper.ConfigurationProvider)
                    .ToArrayAsync();


                return new JqueryDataTablesPagedResults<MasterDataTable>
                {
                    Items = items,
                    TotalSize = size
                };
            }
            catch (Exception ex)
            {

            }
            return new JqueryDataTablesPagedResults<MasterDataTable>
            {
                TotalSize = 0
            };
        }

    }

}
