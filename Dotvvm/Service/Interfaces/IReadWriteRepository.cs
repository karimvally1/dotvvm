using Service.Models;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IReadWriteRepository<T> : IReadOnlyRepository<T> where T : Model
    {
        Task Insert(T model);
        void Update(T model);
        void Delete(T model);
        void SaveChanges();
    }
}
