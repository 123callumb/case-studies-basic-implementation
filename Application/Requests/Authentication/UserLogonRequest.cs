namespace Application.Requests.Authentication
{
    public class UserLogonRequest
    {
        // Just using the email address, we aint got time for hashing passwords
        public string Email { get; set; }
    }
}
