using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}