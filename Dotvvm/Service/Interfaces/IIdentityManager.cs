using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public interface IIdentityManager<T> where T : User
    {
        Task<SignInResult> PasswordSignIn(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<IdentityResult> Create(T user, string password);
    }
}
