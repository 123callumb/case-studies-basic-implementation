using Services.Models.DTOs;

namespace Application.ViewModels
{
    public class ExternalBaseViewModel
    {
        public ExternalBaseViewModel(ExternalUserDTO user)
        {
            User = user;
        }
        public ExternalUserDTO User { get; }
    }
}
