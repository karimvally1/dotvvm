using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public interface IIdentityManager
    {
        Task<SignInResult> PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<IdentityResult> Create(User user, string password);
    }
}
