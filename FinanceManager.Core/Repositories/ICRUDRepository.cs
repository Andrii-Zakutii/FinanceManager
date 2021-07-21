using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface ICRUDRepository<T>
    {
        IQueryable<T> GetAll();
        T Get(long id);
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
    }
}
