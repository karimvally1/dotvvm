using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public interface IIdentityManager
    {
        Task<User> FindByUserName(string userName);
        Task<User> FindByEmail(string email);
        Task<SignInResult> CheckPassword(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<IdentityResult> Create(User user, string password);
    }
}
