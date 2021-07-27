using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Entities.Base
{
    public abstract class PersonalEntity : Entity
    {
        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
