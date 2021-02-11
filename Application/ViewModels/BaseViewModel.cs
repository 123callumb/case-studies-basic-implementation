using Services.Models.Abstract;

namespace Application.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel(AbstractUser user)
        {
            User = user;
        }
        public AbstractUser User { get; }
    }
}
