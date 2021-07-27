using FinanceManager.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Core.Entities
{
    public class MoneyAccount : PersonalEntity
    {
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? InitialSum { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
