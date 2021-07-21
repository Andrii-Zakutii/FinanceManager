using FinanceManager.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Entities
{
    public class MoneyAccount : Entity
    {
        public string Name { get; set; }

        //public decimal InitialSum { get; set; }
        //public DateTime CreatiomTime { get; set; } 

        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
