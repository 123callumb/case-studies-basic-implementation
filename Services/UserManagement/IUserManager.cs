using Services.Models.DTOs;
using System.Threading.Tasks;

namespace Services.UserManagement
{
    public interface IUserManager
    {
        /// <summary>
        /// Load External user, this user is a user from outside of the abcs internal system
        /// </summary>
        /// <param name="userID">Unique id for that user</param>
        /// <returns>Returns the external user object</returns>
        Task<ExternalUserDTO> GetExternalUser(int userID);
        Task<InternalUserDTO> GetInternalUser(int userID);
    }
}
