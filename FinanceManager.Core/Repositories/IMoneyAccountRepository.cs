using FinanceManager.Core.Entities;
using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface IMoneyAccountRepository : ICRUDRepository<MoneyAccount>
    {
        IQueryable<MoneyAccount> GetAll(User user);
    }
}
