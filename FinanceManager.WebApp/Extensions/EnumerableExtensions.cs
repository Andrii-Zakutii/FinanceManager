using FinanceManager.Core.Entities;
using FinanceManager.WebApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager.WebApp.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Transaction> Filter(this IEnumerable<Transaction> transactions, TransactionsFilter filter)
        {
            TimeRange range = new(filter.From, filter.To);

            return transactions.Where(t => range.Include(t.Time.Value))
                .Where(t => t == null ? true : t.MoneyAccountId == filter.AccountId)
                .Where(t => t == null ? true : t.CategoryId == filter.CategoryId);
        }
    }
}
