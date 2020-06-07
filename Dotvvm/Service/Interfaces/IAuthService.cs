using Service.Values;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResult> SignIn(string userNameOrEmail, string password);
    }
}
