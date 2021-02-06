using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Services.AuthenticationManagement
{
    public interface IAuthenticationManager
    {
        Task AuthenticateInternalUser(ISession sessionContext, string email);
        Task AuthenticateExternalUser(ISession sessionContext, string email);
    }
}
