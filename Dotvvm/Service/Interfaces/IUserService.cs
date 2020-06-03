using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<User> GetByUserName(string userName);
        Task<User> GetByEmail(string email);
        Task<IdentityResult> Register(AccountRegister accountRegister);
    }
}
