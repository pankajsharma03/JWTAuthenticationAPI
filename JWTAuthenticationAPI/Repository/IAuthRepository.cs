using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthenticationAPI.Models;

namespace JWTAuthenticationAPI.Repository
{
    public interface IAuthRepository
    {
        public string GenerateToken(User user);
    }
}
