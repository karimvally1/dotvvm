using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IIdentityManager _identityManager;

        public UserService(IIdentityManager identityManager)
        {  
            _identityManager = identityManager;
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

            return await _identityManager.Create(user, accountRegister.Password);
        }
    }
}
