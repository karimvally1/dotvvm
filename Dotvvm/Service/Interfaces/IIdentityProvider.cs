using System.Linq;
using System.Threading.Tasks;
using Service.Models;

namespace Service.Interfaces
{
    public interface IIdentityProvider
    {
        IQueryable<User> GetAll();
        IQueryable<User> GetAllNotInRole(string role);
        Task<User> GetById(string userId);
        Task<User> GetByUserName(string userName);
        Task<User> GetByEmail(string email);
    }
}
