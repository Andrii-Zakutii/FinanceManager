using FinanceManager.Core.Repositories;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations.Base
{
    public abstract class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        protected DataContext Context { get; }

        public CRUDRepository(DataContext context) =>
            Context = context;

        public IQueryable<T> GetAll() => Context.Set<T>();

        public T Get(long id) => Context.Set<T>().Find(id);

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }
    }
}
