using Services.Models.DTOs;
using System.Threading.Tasks;

namespace Services.UserManagement
{
    public interface IUserManager
    {
        Task<ExternalUserDTO> GetExternalUser(int userID);
    }
}
