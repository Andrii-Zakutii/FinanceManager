using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.WebApp.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.WebApp.Controllers
{
    [Authorize]
    public class MoneyAccountController : StandardController<MoneyAccount>
    {
        public MoneyAccountController(IMoneyAccountRepository repository, UserManager<User> userManager)
            : base(repository, userManager)
        {
        }

        protected override bool ValidateEntity(MoneyAccount account) => account.UserId == GetUser().Id;
    }
}
