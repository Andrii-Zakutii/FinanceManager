using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Infrastructure.Data.RepositoryImplementations.Base;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations
{
    public class EFMoneyAccountRepository : EFRepository<MoneyAccount>, IMoneyAccountRepository
    {
        public EFMoneyAccountRepository(DataContext context)
            : base(context)
        {
        }

        public override IQueryable<MoneyAccount> GetAll(User user) => GetAll().Where(a => a.UserId == user.Id);
    }
}
