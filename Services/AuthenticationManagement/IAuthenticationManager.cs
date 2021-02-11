using Microsoft.AspNetCore.Http;
using Services.Models.Abstract;
using System.Threading.Tasks;

namespace Services.AuthenticationManagement
{
    public interface IAuthenticationManager
    {
        Task AuthenticateInternalUser(ISession sessionContext, string email);
        Task AuthenticateExternalUser(ISession sessionContext, string email);
        Task<AbstractUser> GetSessionUser(ISession sessionContext);
    }
}
