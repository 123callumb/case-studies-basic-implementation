using Microsoft.EntityFrameworkCore;
using Services.GenericRepository;
using Services.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace Services.UserManagement.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IGenericQuerier _genericQuerier;
        public UserManager(IGenericQuerier genericQuerier)
        {
            _genericQuerier = genericQuerier;
        }
        public async Task<ExternalUserDTO> GetExternalUser(int userID)
        {
            var user = await _genericQuerier.Load(ExternalUserDTO.MapToDTO, w => w.VendorUserId == userID).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Cannot find external user with the given id.");

            return user;
        }
    }
}
