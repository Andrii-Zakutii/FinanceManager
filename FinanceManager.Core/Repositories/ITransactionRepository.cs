using FinanceManager.Core.Entities;
using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface ITransactionRepository : ICRUDRepository<Transaction>
    {
        IQueryable<Transaction> GetAll(User user, TransactionTypes? type = null);
        IQueryable<Transaction> GetAll(MoneyAccount account, TransactionTypes? type = null);
    }
}
