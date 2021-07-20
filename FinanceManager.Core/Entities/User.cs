using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinanceManager.Core.Entities
{
    public class User : IdentityUser
    {
        public IEnumerable<MoneyAccount> Accounts { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is User another)
                return Id == another.Id;
            else
                return false;
        }

        public override int GetHashCode() => ToString().GetHashCode();

        public override string ToString() => $"{Id}, {UserName}";
    }
}
