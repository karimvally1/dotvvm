using Service.Values;
using System.Threading.Tasks;

namespace Service
{
    public interface IAuthService
    {
        Task<SignInResult> Login(string userName, string password);
    }
}
