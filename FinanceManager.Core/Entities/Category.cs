using FinanceManager.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Entities
{
    public class Category : PersonalEntity
    {
        [Required]
        public string Name { get; set; }

        public TransactionTypes Type { get; set; }

        public string Description { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
