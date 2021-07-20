using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinanceManager.Core.Entities
{
    public class User : IdentityUser
    {
        public IEnumerable<Account> Accounts { get; set; }
    }
}
