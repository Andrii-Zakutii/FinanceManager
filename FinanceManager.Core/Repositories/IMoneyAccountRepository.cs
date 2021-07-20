using FinanceManager.Core.Entities;
using System.Collections.Generic;

namespace FinanceManager.Core.Repositories
{
    public interface IMoneyAccountRepository
    {
        IEnumerable<MoneyAccount> GetAll(User user);
        MoneyAccount Get(long id);
        void Add(MoneyAccount moneyAccount);
        void Update(MoneyAccount moneyAccount);
        void Delete(MoneyAccount moneyAccount);
    }
}
