using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Services.GenericRepository;
using Services.SessionManagement.Helpers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
            var user = await _genericQuerier.Load(InternalUserDTO.MapToDTO, w => w.CompanyEmail == email).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Could not find user.");

            sessionContext.Set(SessionHelper.UserSessionKey, user.UserID);
        }

        public async Task AuthenticateExternalUser(ISession sessionContext, string email)
        {
            var user = await _genericQuerier.Load(ExternalUserDTO.MapToDTO, w => w.Email == email).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Could not find user.");

            sessionContext.Set(SessionHelper.UserSessionKey, user.UserID);
        }
    }
}
