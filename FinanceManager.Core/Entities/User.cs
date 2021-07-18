using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinanceManager.WebApp.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Account> Accounts { get; set; }
    }
}
