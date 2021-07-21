using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Infrastructure.Data.RepositoryImplementations.Base;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations
{
    public class EFMoneyAccountRepository :
        CRUDRepository<MoneyAccount>,
        IMoneyAccountRepository
    {
        public EFMoneyAccountRepository(DataContext context)
            : base(context)
        {
        }

        public IQueryable<MoneyAccount> GetAll(User user) => Context.MoneyAccounts
            .Where(account => account.UserId == user.Id);
    }
}
