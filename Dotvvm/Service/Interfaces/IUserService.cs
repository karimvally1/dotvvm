using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<IdentityResult> Register(AccountRegister accountRegister);
    }
}
