using Service.Models;
using System.Linq;

namespace Service.Interfaces
{
    public interface IReadOnlyRepository<T> where T : Model
    {
        T GetById(int id);
        IQueryable<T> GetAll();
    }
}
