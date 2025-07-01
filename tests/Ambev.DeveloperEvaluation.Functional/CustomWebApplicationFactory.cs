using Ambev.DeveloperEvaluation.ORM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Ambev.DeveloperEvaluation.Functional
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<DefaultContext>));

                if (descriptor != null)
                    services.Remove(descriptor);


                services.AddDbContext<DefaultContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });


                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<DefaultContext>();
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}
