using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JWTAuthenticationAPI.Provider;
using JWTAuthenticationAPI.Models;
using Microsoft.Net.Http.Headers;

namespace JWTAuthenticationAPI.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        private readonly IAuthProvider _authProvider;
        const string SessionName = "token";

        public AuthController(IAuthProvider authProvider)
        {
            _log4net.Info("AuthController constructor initiated.");
            _authProvider = authProvider;
        }

        [HttpPost]
        public IActionResult AuthenticateUser(User user)
        {
            _log4net.Info("AuthController AuthenticateUser method initiated.");
            try
            {
                var token = _authProvider.AuthenticateUser(user);
                if (string.IsNullOrEmpty(token))
                {
                    _log4net.Info("Unauthorized User.");
                    return Unauthorized();
                }
                _log4net.Info("Authorized User.");
                return Ok(new ReturnUser{ Token = token, DisplayName =  user.Username});
            }
            catch(Exception exception)
            {
                _log4net.Error("Exception found while authenticating the user=" + exception.Message);
                return new StatusCodeResult(500);

            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult CheckAuthentication()
        {
          return Ok();
        }
    }
}
