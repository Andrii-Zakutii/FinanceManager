using FinanceManager.Core.Entities;
using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<Category> GetAll(User user, TransactionTypes type);
    }
}
