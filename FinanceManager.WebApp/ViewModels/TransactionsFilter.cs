using System;

namespace FinanceManager.WebApp.ViewModels
{
    public class TransactionsFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public long? AccountId { get; set; }
        public long? CategoryId { get; set; }
    }
}
