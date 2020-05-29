using Service.Interfaces;
using Service.Models;
using Service.Values;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserManager<User> _userManager;

        public UserService(IUserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public void Register(AccountRegister accountRegister)
        {
            var user = new User
            {
                FirstName = accountRegister.FirstName,
                LastName = accountRegister.LastName,
                Email = accountRegister.Email,
                UserName = accountRegister.UserName
            };

            _userManager.Create(user, accountRegister.Password);
        }
    }
}
