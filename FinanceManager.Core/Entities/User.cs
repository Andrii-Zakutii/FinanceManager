using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinanceManager.Core.Entities
{
    public class User : IdentityUser
    {
        public IEnumerable<MoneyAccount> Accounts { get; set; }
    }
}
