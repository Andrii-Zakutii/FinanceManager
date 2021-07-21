using FinanceManager.Core.Entities;
using FinanceManager.Core.Repositories;
using FinanceManager.Infrastructure;
using FinanceManager.Infrastructure.Data;
using FinanceManager.Infrastructure.Data.RepositoryImplementations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinanceManager.WebApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"],
                x => x.MigrationsAssembly("FinanceManager.Infrastructure")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                options => options.LoginPath = "/Identity/Account/Login");

            services.AddTransient<IMoneyAccountRepository, EFMoneyAccountRepository>();
            services.AddTransient<ITransactionRepository, EFTransactionRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MoneyAccount}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            IdentificationSeedData.EnsurePopulated(app);
        }
    }
}
