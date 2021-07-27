using FinanceManager.Core.Entities;
using System;

namespace FinanceManager.WebApp.ViewModels
{
    public class TransactionsFilter
    {
        public DateTime From { get; set; } = DateTime.MinValue;
        public DateTime To { get; set; } = DateTime.MaxValue;
        public long? AccountId { get; set; }
        public long? CategoryId { get; set; }
        public TransactionTypes? Type { get; set; }
    }
}
