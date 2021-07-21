using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Infrastructure.Data.RepositoryImplementations.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations
{
    public class EFTransactionRepository : CRUDRepository<Transaction>, ITransactionRepository
    {
        public EFTransactionRepository(DataContext context)
            : base(context)
        {
        }

        public IQueryable<Transaction> GetAll(User user, TransactionTypes? type = null) => 
            Context.Transactions
            .Where(t => t.Type == type)
            .Include(t => t.MoneyAccount)
            .Where(t => t.MoneyAccount.UserId == user.Id);

        public IQueryable<Transaction> GetAll(MoneyAccount account, TransactionTypes? type = null) => 
            Context.Transactions
            .Where(t => t.Type == type)
            .Where(t => t.MoneyAccountId == account.Id);
    }
}
