using FinanceManager.WebApp.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.WebApp.Models
{
    public class Expense : Transaction
    {
        [Required]
        public ExpenseCategory Category { get; set; }
    }
}
