using FinanceManager.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Entities
{
    public class Expense : Transaction
    {
        [Required]
        public ExpenseCategory Category { get; set; }
    }
}
