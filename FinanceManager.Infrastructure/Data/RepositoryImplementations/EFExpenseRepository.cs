using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Infrastructure.Data.RepositoryImplementations.Base;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations
{
    class EFExpenseRepository :
        TransactionRepository<Expense>,
        IExpenseRepository
    {
        public EFExpenseRepository(DataContext context)
            : base(context)
        {
        }
    }
}
