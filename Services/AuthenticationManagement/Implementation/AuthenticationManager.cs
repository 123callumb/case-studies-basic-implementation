using Microsoft.EntityFrameworkCore;
using Services.Models.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Services.GenericRepository;
using Services.SessionManagement.Helpers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Services.Models.Abstract;
using Services.AuthenticationManagement.Models;
using Services.Models.Enums;
using Services.HashManagement.Implementation;

namespace Services.AuthenticationManagement.Implementation
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IGenericQuerier _genericQuerier;
        public AuthenticationManager(IGenericQuerier genericQuerier)
        {
            _genericQuerier = genericQuerier;
        }
        public async Task AuthenticateInternalUser(ISession sessionContext, string email, string password)
        {
            var user = await _genericQuerier.Load(InternalUserDTO.MapToDTO, w => w.CompanyEmail == email).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Could not find user.");

            if (!HashHelper.CompareHashToValue(user.PasswordHash, password))
                throw new Exception("Password was incorrect");

            // The user object is stored within the session, this is not secure what so ever but this is to speed the process up
            sessionContext.Set(SessionHelper.UserSessionKey, user);
        }

        public async Task AuthenticateExternalUser(ISession sessionContext, string email, string password)
        {
            var user = await _genericQuerier.Load(ExternalUserDTO.MapToDTO, w => w.Email == email).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Could not find user.");

            if (!HashHelper.CompareHashToValue(user.PasswordHash, password))
                throw new Exception("Password was incorrect");

            sessionContext.Set(SessionHelper.UserSessionKey, user);
        }

        // If this turns out to be slow becuase it has to access the database everytime we want the session user then when authenticating the user
        // we shoud cache them in memory and then pull them from the cache instead of the db.
        public async Task<AbstractUser> GetSessionUser(ISession sessionContext)
        {
            AuthenticatedSession authSession = sessionContext.GetUserSession();

            if (authSession == null)
                return null;

            AbstractUser sessionUser;

            switch (authSession.UserType)
            {
                case UserTypeEnum.EXTERNAL:
                    sessionUser = await _genericQuerier.Load(ExternalUserDTO.MapToDTO, w => w.VendorUserId == authSession.UserID).FirstOrDefaultAsync();
                    break;
                case UserTypeEnum.INTERNAL:
                    sessionUser = await _genericQuerier.Load(InternalUserDTO.MapToDTO, w => w.UserId == authSession.UserID).FirstOrDefaultAsync();
                    break;
                default:
                    sessionUser = null;
                    break;
            }

            return sessionUser;
        }
    }
}
