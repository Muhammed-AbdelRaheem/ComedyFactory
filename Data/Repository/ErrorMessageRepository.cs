using Data.Context;
using Data.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ErrorMessageRepository : IErrorMessageRepository
    {
        readonly WriteDbContext _context;
        private readonly ReadDBContext _read;


        public ErrorMessageRepository(WriteDbContext context, ReadDBContext read)
        {
            _context = context;
            _read = read;
        }

     

        public async Task<string?> GetErrorMessageByKeyAsync(string key, string language)
        {
            return await _read.ErrorMessages.Where(s => s.Key == key).OrderBy(e => e.DisplayOrder)
                .ThenBy(e => e.Id).Select(e => language == "ar" ? e.ArDescription : e.EnDescription).FirstOrDefaultAsync();

        }

    
    }

}
