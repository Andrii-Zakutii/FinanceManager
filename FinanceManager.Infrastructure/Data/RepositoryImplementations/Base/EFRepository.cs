using FinanceManager.Core.Entities;
using FinanceManager.Core.Entities.Base;
using FinanceManager.Core.Repositories;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations.Base
{
    public abstract class EFRepository<T> : IRepository<T> where T : Entity
    {
        protected DataContext Context { get; }

        public EFRepository(DataContext context) =>
            Context = context;

        public abstract IQueryable<T> GetAll(User user);

        public virtual IQueryable<T> GetAll() => Context.Set<T>();

        public virtual T Get(long id) => Context.Set<T>().Find(id);

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }
    }
}
