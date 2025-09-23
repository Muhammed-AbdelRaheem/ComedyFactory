using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IApiClientRepository
    {
   
        public Task<ApiClient?> GetValidClient(string clientId, string clientToken);

   
        public Task<bool> CheckValidClient(string clientId, string clientToken);

    }
}
