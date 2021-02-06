using Application.Requests.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.AuthenticationManagement;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IAuthenticationManager authenticationManager) : base(authenticationManager)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Really need to add an error controller/an ooops something went wrong page." });
            }
        }

        [HttpPost]
        public async Task<JsonResult> AuthenticateInternalUser([FromBody]UserLogonRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request sent was null");

                await _authManager.AuthenticateInternalUser(HttpContext.Session, request.Email);
                return new JsonResult(new { success = true, message = "User logged, session started for user." });
            }
            catch (Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to login to sytem."});
            }
        } 

        [HttpPost]
        public async Task<JsonResult> AuthenticateExternalUser([FromBody] UserLogonRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request sent was null");

                await _authManager.AuthenticateExternalUser(HttpContext.Session, request.Email);
                return new JsonResult(new { success = true, message = "User logged, session started for user." });
            }
            catch(Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to login to sytem." });
            }
        }
    }
}
