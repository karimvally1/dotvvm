using Service.Interfaces;
using Service.Models;
using Service.Values;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class AuthService : IAuthService
    {
        private readonly IIdentityManager _identityManager;
        private readonly IIdentityProvider _identityProvider;

        public AuthService(IIdentityManager identityManager, IIdentityProvider identityProvider)
        {
            _identityManager = identityManager;
            _identityProvider = identityProvider;
        }

        public async Task<SignInResult> SignIn(string userNameOrEmail, string password)
        {
            var user = userNameOrEmail.Contains("@") ?
                await _identityProvider.GetByEmail(userNameOrEmail) :
                await _identityProvider.GetByUserName(userNameOrEmail);

            if (user == default(User))
            {
                return new SignInResult
                {
                    Succeeded = false
                };
            }

            var result = await _identityManager.PasswordSignIn(user.UserName, password, true, true);

            if (!result.Succeeded)
                return result;

            var claims = new Dictionary<string, string>
            {
                { "FirstName", user.FirstName },
                { "LastName", user.LastName }
            };

            await _identityManager.AddClaims(user.UserName, claims);

            return result;
        }  
    }
}
