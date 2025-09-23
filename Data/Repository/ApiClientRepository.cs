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
    public class ApiClientRepository : IApiClientRepository
    {
        private readonly WriteDbContext _context;

        public ApiClientRepository(WriteDbContext context)
        {
            _context = context;
        }

  
        public async Task<ApiClient?> GetValidClient(string clientId, string clientToken)
        {
            return await _context.ApiClient.Where(e => e != null && e.ClientId == clientId && e.ClientToken == clientToken)
                .OrderBy(e => e!.DisplayOrder)
                .ThenBy(e => e!.Id).FirstOrDefaultAsync();
        }
      

        public async Task<bool> CheckValidClient(string clientId, string clientToken)
        {
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientToken))
                return false;
            var isvalid = await _context.ApiClient.Where(e => e != null && e.Hidden != true && e.Active &&
                                                              e.ClientId == clientId && e.ClientToken == clientToken).AnyAsync();

            return isvalid;
        }

    }
}
