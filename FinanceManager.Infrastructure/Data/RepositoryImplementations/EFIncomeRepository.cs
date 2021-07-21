using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Infrastructure.Data.RepositoryImplementations.Base;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations
{
    public class EFIncomeRepository :
        TransactionRepository<Income>,
        IIncomeRepository
    {
        public EFIncomeRepository(DataContext context)
            : base(context)
        {
        }
    }
}
