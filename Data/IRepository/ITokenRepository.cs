using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface ITokenRepository
    {
        string GenerateAccessToken(IEnumerable<Claim> claims, int expiryMinutes = 0);
        string GenerateRefreshToken();
     

    }

}
