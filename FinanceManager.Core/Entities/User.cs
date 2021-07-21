using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager.Core.Entities
{
    public class User : IdentityUser
    {
        public IEnumerable<MoneyAccount> Accounts { get; set; }

        #region Statistics
        public IEnumerable<Transaction> GetTransactions(
            TimeRange timeRange = null,
            TransactionTypes? type = null)
        {
            foreach (var account in Accounts)
                foreach (var transaction in account.Transactions)
                    if (timeRange?.Include(transaction) ?? true)
                        if (type == transaction.Type)
                            yield return transaction;
        }

        public IEnumerable<Transaction> GetIncomes(TimeRange range = null) =>
            GetTransactions(range, TransactionTypes.Income);

        public IEnumerable<Transaction> GetExpenses(TimeRange range = null) =>
            GetTransactions(range, TransactionTypes.Expense);

        public decimal GetTransactionSum(TransactionTypes type, TimeRange timeRange = null) =>
            GetTransactions(timeRange, type).Sum(t => t?.Sum ?? 0);

        public decimal GetExpenseSum(TimeRange range = null) =>
            GetTransactionSum(TransactionTypes.Expense, range);

        public decimal GetIncomeSum(TimeRange range = null) =>
            GetTransactionSum(TransactionTypes.Income, range);

        public decimal GetTotalIncome(TimeRange range = null) =>
            GetIncomeSum(range) - GetExpenseSum(range);
        #endregion 
    }
}
