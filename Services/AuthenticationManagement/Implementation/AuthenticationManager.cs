using Microsoft.EntityFrameworkCore;
using Services.Models.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Services.GenericRepository;
using Services.SessionManagement.Helpers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Services.DTOs;

namespace Services.AuthenticationManagement.Implementation
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IGenericQuerier _genericQuerier;
        public AuthenticationManager(IGenericQuerier genericQuerier)
        {
            _genericQuerier = genericQuerier;
        }
        public async Task AuthenticateInternalUser(ISession sessionContext, string email)
        {
            IUserDTO user = await _genericQuerier.Load(InternalUserDTO.MapToDTO, w => w.CompanyEmail == email).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Could not find user.");

            // The user object is stored within the session, this is not secure what so ever but this is to speed the process up
            sessionContext.Set(SessionHelper.UserSessionKey, user);
        }

        public async Task AuthenticateExternalUser(ISession sessionContext, string email)
        {
            IUserDTO user = await _genericQuerier.Load(ExternalUserDTO.MapToDTO, w => w.Email == email).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Could not find user.");

            sessionContext.Set(SessionHelper.UserSessionKey, user);
        }
    }
}
