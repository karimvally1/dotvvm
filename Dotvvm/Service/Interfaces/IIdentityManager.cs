using Service.Models;
using Service.Values;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IIdentityManager<T> where T : User
    {
        Task<IdentityResult> Create(T user, string password);
    }
}
