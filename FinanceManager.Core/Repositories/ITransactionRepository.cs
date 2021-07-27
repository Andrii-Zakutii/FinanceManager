using FinanceManager.Core.Entities;
using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IQueryable<Transaction> GetAll(MoneyAccount account);
    }
}
