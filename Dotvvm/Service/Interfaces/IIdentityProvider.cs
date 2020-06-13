using Service.Models;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IIdentityProvider
    {
        Task<User> GetById(string userId);
        Task<User> GetByUserName(string userName);
        Task<User> GetByEmail(string email);
    }
}
