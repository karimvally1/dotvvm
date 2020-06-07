using Service.Models;
using Service.Values;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IIdentityManager
    {
        Task AddClaims(string userName, IDictionary<string, string> claims);
        Task<SignInResult> PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure);

        Task<IdentityResult> Create(User user, string password);
    }
}
