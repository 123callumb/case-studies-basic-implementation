using Services.Models.Enums;
using System;
using System.Linq.Expressions;

namespace Services.DTOs
{
    // Shared user interface between internal and external users
    public interface IUserDTO
    {
        public int UserID { get; set; }
        public String Email { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
