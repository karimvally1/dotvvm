using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(AccountRegister accountRegister);
        Task<IdentityResult> ConfirmEmail(string userId, string token);
        Task SendEmailConfirmation(string aspnetUserId);
    }
}
