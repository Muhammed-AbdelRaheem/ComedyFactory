using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IErrorMessageRepository
    {
       
        public Task<string?> GetErrorMessageByKeyAsync(string key, string language);

    }
}
