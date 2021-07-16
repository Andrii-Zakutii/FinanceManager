using FinanceManager.WebApp.Models.Base;
using System;

namespace FinanceManager.WebApp.Models
{
    public class Transaction : Entity
    {
        public decimal Sum { get; set; }
        public DateTime Time { get; set; }
    }
}
