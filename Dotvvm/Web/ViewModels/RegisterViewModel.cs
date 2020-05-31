using Service;
using Service.Values;
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

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        private readonly IUserService _userService;

        public RegisterViewModel(IUserService userService)
        {
            Title = "Create an account";
            _userService = userService;
        }

        public async void Create()
        {
            var accountRegister = new AccountRegister
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                UserName = UserName,
                Password = Password
            };

            var result = await _userService.Register(accountRegister);
        }
    }
}

