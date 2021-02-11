using Microsoft.AspNetCore.Mvc.Filters;
using Services.Models.Enums;

namespace Services.Filters.Attributes
{
    public class RequireUser : ActionFilterAttribute
    {
        private readonly UserTypeEnum _userType;
        public RequireUser(UserTypeEnum userType)
        {
            _userType = userType;
        }

        public UserTypeEnum Get() => _userType;
    }
}
