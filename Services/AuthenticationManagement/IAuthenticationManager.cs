using Microsoft.AspNetCore.Http;
using Services.Models.Abstract;
using System.Threading.Tasks;

namespace Services.AuthenticationManagement
{
    public interface IAuthenticationManager
    {
        /// <summary>
        /// For authenticating internal users. (Part of the login process)
        /// </summary>
        /// <param name="sessionContext"></param>
        /// <param name="email">Users email address</param>
        /// <returns>Void</returns>
        Task AuthenticateInternalUser(ISession sessionContext, string email);
        /// <summary>
        /// For authenticating external users. (Part of the login process)
        /// </summary>
        /// <param name="sessionContext"></param>
        /// <param name="email">Users email address</param>
        /// <returns>Void</returns>
        Task AuthenticateExternalUser(ISession sessionContext, string email);
        /// <summary>
        /// Get a users current session user external or internal, will return null if the user does
        /// not have a logged in session.
        /// </summary>
        /// <param name="sessionContext"></param>
        /// <returns>Abstract user, an abstract instance of both an external or internal user.</returns>
        Task<AbstractUser> GetSessionUser(ISession sessionContext);
    }
}
