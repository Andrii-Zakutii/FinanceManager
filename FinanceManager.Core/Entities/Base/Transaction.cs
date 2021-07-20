using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Core.Entities.Base
{
    public abstract class Transaction : Entity
    {
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Sum { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public string Description { get; set; }
    }
}
