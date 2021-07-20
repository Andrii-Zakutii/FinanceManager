using FinanceManager.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Entities
{
    public class Income : Transaction
    {
        [Required]
        public IncomeCategory Category { get; set; }
    }
}
