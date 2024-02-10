using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinShark.models;

namespace FinShark.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}