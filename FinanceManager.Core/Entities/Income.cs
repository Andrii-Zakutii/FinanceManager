using FinanceManager.WebApp.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.WebApp.Models
{
    public class Income : Transaction
    {
        [Required]
        public IncomeCategory Category { get; set; }
    }
}
