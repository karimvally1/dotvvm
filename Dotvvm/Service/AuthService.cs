using Service.Interfaces;
using Service.Models;
using Service.Values;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            var claims = new List<Claim>
            {
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName)
            };

            var roles = await _identityManager.GetUserRoles(user.UserName);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            await _identityManager.AddClaims(user.UserName, claims);

            return result;
        }  
    }
}
