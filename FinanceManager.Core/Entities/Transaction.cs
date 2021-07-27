using FinanceManager.Core.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Core.Entities
{
    public class Transaction : Entity
    {
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Sum { get; set; }

        [Required]
        public TransactionTypes? Type { get; set; }

        [Required]
        public DateTime? Time { get; set; }

        public string Description { get; set; }

        public long? CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public long MoneyAccountId { get; set; }

        public MoneyAccount MoneyAccount { get; set; }
    }
}
