using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager.Infrastructure.Data.RepositoryImplementations
{
    public class EFMoneyAccountRepository : IMoneyAccountRepository
    {
        private readonly DataContext _context;

        public EFMoneyAccountRepository(DataContext context) =>
            _context = context;

        public IEnumerable<MoneyAccount> GetAll(User user) =>
            _context.MoneyAccounts.Where(account => account.UserId == user.Id).ToArray();

        public MoneyAccount Get(long id) =>
            _context.MoneyAccounts.Find(id);

        public void Update(MoneyAccount account)
        {
            _context.MoneyAccounts.Update(account);
            _context.SaveChanges();
        }

        public void Add(MoneyAccount account)
        {
            _context.MoneyAccounts.Add(account);
            _context.SaveChanges();
        }

        public void Delete(MoneyAccount account)
        {
            _context.MoneyAccounts.Remove(account);
            _context.SaveChanges();
        }
    }
}
