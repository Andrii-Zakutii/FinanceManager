using FinanceManager.Core.Entities;
using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface IIncomeRepository : ICRUDRepository<Income>
    {
        IQueryable<Income> GetAll(User user);
        IQueryable<Income> GetAll(MoneyAccount account);
    }
}
