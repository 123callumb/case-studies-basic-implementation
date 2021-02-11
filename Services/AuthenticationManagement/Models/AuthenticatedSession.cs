using Services.Models.Enums;

namespace Services.AuthenticationManagement.Models
{
    public class AuthenticatedSession
    {
        public AuthenticatedSession(int userID, UserTypeEnum userType)
        {
            UserID = userID;
            UserType = userType;
        }
        public int UserID { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
