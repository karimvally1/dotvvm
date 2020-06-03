using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public class AuthService : IAuthService
    {
        private readonly IIdentityManager _identityManager;

        public AuthService(IIdentityManager identityManager)
        {
            _identityManager = identityManager;
        }

        public async Task<SignInResult> Login(string userName, string password)
        {
            return await _identityManager.PasswordSignIn(userName, password, true, true);
        }
    }
}
