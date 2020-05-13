using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class RegisterViewModel : MasterPageViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public RegisterViewModel()
        {
            Title = "Create an account";
        }

        public void Create()
        {  

        }
    }
}

