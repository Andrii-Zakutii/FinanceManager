using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Infrastructure.Data.RepositoryImplementations.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations
{
    public class EFCategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(DataContext context)
            : base(context)
        {
        }

        public override Category Get(long id) => GetAll()
            .Where(c => c.Id == id)
            .Include(c => c.Transactions)
            .FirstOrDefault();

        public IQueryable<Category> GetAll(User user, TransactionTypes type) => GetAll(user)
            .Where(c => c.Type == type);

        public override IQueryable<Category> GetAll(User user) => GetAll()
            .Where(c => c.User.Id == user.Id);
    }
}
