using AutoMapper;
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
using AutoMapper.QueryableExtensions;

namespace Data.Repository
{
    public class PersonalDataRepository : IPersonalDataRepository
    {
        private readonly WriteDbContext _context;
        private readonly ReadDBContext _read;
        private readonly IMapper _mapper;
        private readonly IConfigurationRepository _configurationRepository;

        public PersonalDataRepository(WriteDbContext context,ReadDBContext read , IMapper mapper,IConfigurationRepository configurationRepository)
        {
            _context = context;
            _read = read;
            _mapper = mapper;
            _configurationRepository = configurationRepository;
        }
        public Task<bool> AddAsync(PersonalData personalData)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddData(string? language, PersonalDataVM personalDataVM)
        {
            try
            {
                bool IsExist = await _context.PersonalDatas.AnyAsync(e => e.Email.ToLower() == personalDataVM.Email.ToLower());
                if (IsExist == true)
                    return false;

                await SendPersonalDataAsync(language, personalDataVM);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;

        }

        private async Task<bool> SendPersonalDataAsync(string? language, PersonalDataVM personalDataVM)
        {


            try
            {
                _context.PersonalDatas.Add(new PersonalData()
                {
                    CreatedOnUtc = Extantion.AddUtcTime(),
                    DisplayOrder = 100,
                    Hidden = false,
                    Email = personalDataVM.Email,
                    City = personalDataVM.City,
                    NationalityId = personalDataVM.NationalityId,
                    DesireId = personalDataVM.DesireId,
                    CityId = personalDataVM.CityId,
                    Phone = personalDataVM.Phone,
                    Age = personalDataVM.Age,
                    Genders = personalDataVM.Genders,
                    Name = personalDataVM.Name,
                    UpdatedOnUtc = Extantion.AddUtcTime(),
                });

                await _context.SaveChangesAsync();

                var config = await _configurationRepository.GetFirstConfigurationAsync();
                List<int> mailSent = new List<int>();

                if (config != null && !string.IsNullOrWhiteSpace(config.EmailSender))
                {
                    var templateBlock = _context.Blocks.Where(e => e.BlockType == BlockType.ThanksEmail).FirstOrDefault();

                    if (templateBlock != null)
                    {
                        string content;

                        if (language == "ar")
                        {
                            content = templateBlock.ArContent?.Replace("%name%", personalDataVM.Name);
                        }
                        else
                        {
                            content = templateBlock.EnContent?.Replace("%name%", personalDataVM.Name);
                        }

                       
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonalData>> GetAllAsync(bool hidden = false)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonalData?> GetPersonalDataAsync(int id, bool hidden = false)
        {
            return await _context.PersonalDatas.Where(e => e.Id == id && (hidden == false || e.Hidden != hidden)).FirstOrDefaultAsync();
        }


        public async Task<JqueryDataTablesPagedResults<PersonalDataTable>> GetPersonalDataTableAsync(JqueryDataTablesParameters table, FilterVM filterVM)
        {
            try
            {

                var query = _read.PersonalDatas.AsNoTracking();

                query = SearchOptionsProcessor<PersonalDataTable, PersonalData>.Apply(query, table.Columns);
                query = SortOptionsProcessor<PersonalDataTable, PersonalData>.Apply(query, table);

                query = query.Where(
                   e =>
                   string.IsNullOrEmpty(table.Search.Value) ||
                   (
                       e.Id.ToString().Contains(table.Search.Value)
                       ||
                       e.Name!.ToLower().Contains(table.Search.Value.ToLower())
                       ||
                       e.Email!.ToLower().Contains(table.Search.Value.ToLower())

                   )
               );

                if (filterVM.Email != null || filterVM.Name != null || filterVM.Age != null || filterVM.Phone != null)
                {
                    query = query.Where(e =>

                        (filterVM.Email == null || e.Email.Contains(filterVM.Email)) &&
                        (filterVM.Name == null || e.Name.Contains(filterVM.Name)) &&
                        (filterVM.Age == null || e.Age.ToString().Contains(filterVM.Age.ToString())) &&
                        (filterVM.Phone == null || e.Phone.Contains(filterVM.Phone))

                    );
                }



                var size = await query.CountAsync();

                var items = await query
                    .AsNoTracking()
                    .Skip(table.Start / table.Length * table.Length)
                    .Take(table.Length)
                    .ProjectTo<PersonalDataTable>(_mapper.ConfigurationProvider)
                    .ToArrayAsync();


                return new JqueryDataTablesPagedResults<PersonalDataTable>
                {
                    Items = items,
                    TotalSize = size
                };
            }
            catch (Exception ex)
            {

            }
            return new JqueryDataTablesPagedResults<PersonalDataTable>
            {
                TotalSize = 0
            };
        }
    }
}
