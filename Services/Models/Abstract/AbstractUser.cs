using Services.Models.Enums;
using System;

namespace Services.Models.Abstract
{
    // Shared user interface between internal and external users
    // need to add firstname and last name here
    public abstract class AbstractUser
    {
        public int UserID { get; set; }
        public String Email { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
