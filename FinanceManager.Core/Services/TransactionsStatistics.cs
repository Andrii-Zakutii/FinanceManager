using FinanceManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceManager.Core.Services
{
    public record TransactionsStatistics
    {
        private readonly IEnumerable<Transaction> _transactions;

        public TransactionsStatistics(IEnumerable<Transaction> transactions)
        {
            if (transactions == null)
                throw new ArgumentNullException(nameof(transactions));

            _transactions = transactions;
        }

        public decimal GetSum(TimeRange range, TransactionTypes type)
        {
            if (range == null)
                throw new ArgumentNullException(nameof(range));

            return _transactions.Where(t => (t.Type == type) && range.Include(t.Time.Value)).Sum(t => t.Sum.Value);
        }

        public decimal GetSum(TransactionTypes type) => GetSum(TimeRange.Default, type);

        public decimal GetShare(Transaction transaction, TimeRange range)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            if (range == null)
                throw new ArgumentNullException(nameof(range));

            if (range.Include(transaction.Time.Value) == false)
                throw new ArgumentException(nameof(transaction));

            return transaction.Sum.Value / GetSum(range, transaction.Type.Value);
        }

        public decimal GetShare(Transaction transaction) => GetShare(transaction, TimeRange.Default);

        public decimal GetTotalIncome(TimeRange range) =>
            GetSum(range, TransactionTypes.Income) - GetSum(range, TransactionTypes.Expense);

        public decimal GetTotalIncome() => GetTotalIncome(TimeRange.Default);
    }
}
