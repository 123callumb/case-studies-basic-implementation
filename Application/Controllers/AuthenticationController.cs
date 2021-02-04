using Application.Requests.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {

        }

        [HttpPost]
        public async Task<JsonResult> AuthenticateInternalUser([FromBody]UserLogonRequest request)
        {
            try
            {
                if (request == null)
                    throw new Exception("Request sent was null");



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
                return new JsonResult(new { success = false, message = "Not implemented." });
            }
            catch(Exception e)
            {
                return new JsonResult(new { success = false, message = "Failed to login to sytem." });
            }
        }
    }
}
