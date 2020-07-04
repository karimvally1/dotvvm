using Service.Models;
using Service.Values;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IIdentityManager
    {
        Task<IList<string>> GetUserRoles(string userName);
        Task AddClaims(string userName, IList<Claim> claims);
        Task SignIn(string userName);
        Task<SignInResult> PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task SignOut();
        Task<string> CreateEmailConfirmationToken(string userName);
        Task<IdentityResult> ConfirmEmailToken(string userName, string token);
        Task<bool> IsEmailConfirmed(string userName);
        Task<IdentityResult> Create(User user, string password);
    }
}
