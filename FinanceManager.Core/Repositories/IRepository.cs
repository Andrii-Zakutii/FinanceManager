using FinanceManager.Core.Entities;
using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(User user);
        IQueryable<T> GetAll();
        T Get(long id);
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
    }
}
