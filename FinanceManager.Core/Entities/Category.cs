using FinanceManager.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FinanceManager.Core.Entities
{
    public class Category : Entity
    {
        [Required]
        public string Name { get; set; }

        public CategoryTypes Type { get; set; }

        public string Description { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }

        #region Statistics
        public decimal GetTransactionsSum(User user, TimeRange range = null) => Transactions
            .Where(t => t.BelongsTo(user))
            .Where(t => range.Include(t))
            .Sum(t => t?.Sum ?? 0);

        public decimal GetTransactionsSum(MoneyAccount account, TimeRange range = null) => Transactions
            .Where(t => t.BelongsTo(account))
            .Where(t => range.Include(t))
            .Sum(t => t?.Sum ?? 0);

        public decimal GetShare(User user, TimeRange range)
        {
            decimal total;

            if (Type == CategoryTypes.ExpenseCategory)
                total = user.GetExpenseSum(range);
            else
                total = user.GetIncomeSum(range);

            return GetTransactionsSum(user, range) / total;
        }

        public decimal GetShare(MoneyAccount account, TimeRange range)
        {
            decimal total;

            if (Type == CategoryTypes.ExpenseCategory)
                total = account.GetExpenseSum();
            else
                total = account.GetIncomeSum();

            return GetTransactionsSum(account, range) / total;
        }
        #endregion
    }
}