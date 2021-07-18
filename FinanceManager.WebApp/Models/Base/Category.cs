using System.ComponentModel.DataAnnotations;

namespace FinanceManager.WebApp.Models.Base
{
    public abstract class Category : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}