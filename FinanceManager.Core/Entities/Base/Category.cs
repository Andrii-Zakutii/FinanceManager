using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Entities.Base
{
    public abstract class Category : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}