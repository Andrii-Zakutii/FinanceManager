using FinanceManager.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure
{
    class IdentificationSeedData
    {
        private const string _userEmail = "user123@example.com";
        private const string _userPasssword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

                User user = await userManager.FindByEmailAsync(_userEmail);

                if (user == null)
                {
                    user = new User { UserName = _userEmail };
                    await userManager.CreateAsync(user, _userPasssword);
                }
            }
        }
    }
}
