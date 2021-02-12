using Services.Models.Abstract;

namespace Application.ViewModels
{
    public class BaseViewModel
    {
        public AbstractUser user { get; set; }

        public BaseViewModel(AbstractUser user)
        {
            this.user = user;
        }
    }
}