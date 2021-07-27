using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Infrastructure.Data.RepositoryImplementations.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations
{
    public class EFTransactionRepository : EFRepository<Transaction>, ITransactionRepository
    {
        public EFTransactionRepository(DataContext context)
            : base(context)
        {
        }

        public override Transaction Get(long id) => GetAll()
            .Include(t => t.MoneyAccount)
            .Include(t => t.Category)
            .FirstOrDefault(t => t.Id == id);

        public override IQueryable<Transaction> GetAll(User user) => GetAll().Where(t => t.MoneyAccount.User.Id == user.Id);

        public IQueryable<Transaction> GetAll(MoneyAccount account) => GetAll().Where(t => t.MoneyAccount.Id == account.Id);
    }
}
