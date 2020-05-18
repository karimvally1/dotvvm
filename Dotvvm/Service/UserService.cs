using Service.Interfaces;
using Service.Models;
using Service.Values;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IAppUserManager<User> _appUserManager;

        public UserService(IAppUserManager<User> appUserManager)
        {
            _appUserManager = appUserManager;
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

            _appUserManager.Create(user, accountRegister.Password);
        }
    }
}
