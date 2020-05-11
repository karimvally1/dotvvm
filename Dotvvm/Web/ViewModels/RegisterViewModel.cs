using Service.Models;

namespace Web.ViewModels
{
    public class RegisterViewModel : MasterPageViewModel
    {
        public User User { get; set; }

        public RegisterViewModel()
        {
            Title = "Register";
        }

        public void Create()
        {
            User = new User
            {
                FirstName = "Karim",
                LastName = "Vally"
            };
        }
    }
}

