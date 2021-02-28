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

        /// <summary>
        /// Used for loading the login screen
        /// </summary>
        /// <returns>Returns a login screen for external and internal users.</returns>
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

        /// <summary>
        /// Authenticates abc users into the system. Will redirect them to their homepage
        /// </summary>
        /// <param name="request">Request asks for their email address</param>
        /// <returns>Returns a json result to tell the javascript if their login was successful</returns>
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

        /// <summary>
        /// Authenticates external vendor users into the system. Will redirect them to their homepage
        /// </summary>
        /// <param name="request">Request asks for their email address</param>
        /// <returns>Returns a json result to tell the javascript if their login was successful</returns>
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
