using Service.Interfaces;
using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IIdentityManager<User> _userManager;

        public UserService(IIdentityManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(AccountRegister accountRegister)
        {
            var user = new User
            {
                FirstName = accountRegister.FirstName,
                LastName = accountRegister.LastName,
                Email = accountRegister.Email,
                UserName = accountRegister.UserName
            };

            return await _userManager.Create(user, accountRegister.Password);
        }
    }
}
