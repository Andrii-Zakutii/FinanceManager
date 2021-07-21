using FinanceManager.Core.Entities;
using System.Linq;

namespace FinanceManager.Core.Repositories
{
    public interface IExpenseRepository : ICRUDRepository<Expense>
    {
        IQueryable<Expense> GetAll(User user);
        IQueryable<Expense> GetAll(MoneyAccount account);
    }
}
