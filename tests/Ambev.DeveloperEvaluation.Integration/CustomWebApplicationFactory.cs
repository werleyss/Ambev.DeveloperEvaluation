using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Integration
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Ambev.DeveloperEvaluation.WebApi.Program>
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
                    options.UseInMemoryDatabase("TestDbIntegration");
                });
                               
               
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<DefaultContext>();
                    db.Database.EnsureCreated();

                    db.Products.AddRange(
                        new Product
                        {
                            Id = Guid.Parse("4af0b2d8-230b-41de-a7f4-45b991ad6e4b"),
                            Description = "Product 1",
                            Price = 10.0m
                        }
                    );

                    db.Users.AddRange(
                        new User
                        {
                            Id = Guid.Parse("be5ce2c2-c320-41d5-ae59-eb3f66d1b656"),
                            Username = "User 1",
                            Password = "@Evaluation123",
                            Phone = "6399999-0000",
                            Email = "email1@test.com",
                            Status = UserStatus.Active,
                            Role = UserRole.Admin
                        }
                    );

                    db.SaveChanges();
                }
            });
        }
    }


}
