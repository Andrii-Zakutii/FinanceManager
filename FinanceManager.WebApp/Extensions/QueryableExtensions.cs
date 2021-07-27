using FinanceManager.Core.Entities;
using FinanceManager.WebApp.ViewModels;
using System;
using System.Linq;

namespace FinanceManager.WebApp.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<Transaction> Apply(this IQueryable<Transaction> transactions, TransactionsFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            return transactions
                .Where(t => filter.Type == null || t.Type == filter.Type)
                .Where(t => (t.Time.Value >= filter.From) && (t.Time.Value <= filter.To))
                .Where(t => filter.AccountId == null || t.MoneyAccountId == filter.AccountId)
                .Where(t => filter.CategoryId == null || t.CategoryId == filter.CategoryId);
        }
    }
}
