using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FinanceManager.WebApp.Areas.Identity.IdentityHostingStartup))]
namespace FinanceManager.WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}