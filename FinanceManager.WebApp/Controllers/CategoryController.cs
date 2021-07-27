using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.WebApp.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.WebApp.Controllers
{
    [Authorize]
    public class CategoryController : StandardController<Category>
    {
        public CategoryController(ICategoryRepository repository, UserManager<User> userManager)
            : base(repository, userManager)
        {
        }

        protected override bool ValidateEntity(Category category) => category.UserId == GetUser().Id;
    }
}
