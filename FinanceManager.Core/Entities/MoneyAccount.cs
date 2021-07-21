using FinanceManager.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FinanceManager.Core.Entities
{
    public class MoneyAccount : Entity
    {
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? InitialSum { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        #region Statistics
        public IEnumerable<Transaction> GetTransactions(TimeRange range = null, TransactionTypes? type = null) =>
            Transactions.Where(t => range?.Include(t) ?? true)
            .Where(t => type == t.Type);

        public IEnumerable<Transaction> GetIncomes(TimeRange range = null) =>
            GetTransactions(range, TransactionTypes.Income);

        public IEnumerable<Transaction> GetExpenses(TimeRange range) =>
            GetTransactions(range, TransactionTypes.Expense);

        public decimal GetTransactionSum(TransactionTypes type, TimeRange range = null) =>
            GetTransactions(range, type).Sum(i => i?.Sum ?? 0);

        public decimal GetIncomeSum(TimeRange range = null) => GetTransactionSum(TransactionTypes.Income, range);

        public decimal GetExpenseSum(TimeRange range = null) => GetTransactionSum(TransactionTypes.Expense, range);

        public decimal GetTotalIncome(TimeRange range = null) => GetIncomeSum(range) - GetExpenseSum(range);

        public bool BelongsTo(User user) => UserId == user?.Id;
        #endregion
    }
}
