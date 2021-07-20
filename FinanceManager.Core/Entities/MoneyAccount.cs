using FinanceManager.Core.Entities.Base;
using System.Collections.Generic;

namespace FinanceManager.Core.Entities
{
    public class MoneyAccount : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
