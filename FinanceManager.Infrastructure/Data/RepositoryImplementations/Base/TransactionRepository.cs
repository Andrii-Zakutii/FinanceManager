using FinanceManager.Core.Entities;
using FinanceManager.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations.Base
{
    public abstract class TransactionRepository<T> :
        CRUDRepository<T> where T : Transaction
    {
        public TransactionRepository(DataContext context)
            : base(context)
        {
        }

        public IQueryable<T> GetAll(User user) => Context.Set<T>()
            .Include(account => account.MoneyAccount)
            .Where(income => income.MoneyAccount.UserId == user.Id);

        public IQueryable<T> GetAll(MoneyAccount account) => Context.Set<T>()
            .Where(income => income.MoneyAccountId == account.Id);
    }
}
