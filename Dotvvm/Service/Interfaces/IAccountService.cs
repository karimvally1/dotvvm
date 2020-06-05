using Service.Values;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(AccountRegister accountRegister);
    }
}
