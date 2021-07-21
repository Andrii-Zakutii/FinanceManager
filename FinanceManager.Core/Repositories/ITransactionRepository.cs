using FinanceManager.Core.Entities;
using FinanceManager.Core.Entities.Base;
using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface ITransactionRepository : ICRUDRepository<Transaction>
    {
        IQueryable<Transaction> GetAll(User user);
        IQueryable<Transaction> GetAll(MoneyAccount account);
    }
}
