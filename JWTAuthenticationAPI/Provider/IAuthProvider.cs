using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthenticationAPI.Models;

namespace JWTAuthenticationAPI.Provider
{
    public interface IAuthProvider
    {
        public string AuthenticateUser(User user);
    }
}
