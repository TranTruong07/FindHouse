using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Infrastructure.Data.SeedData;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.WebApp.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<FindHouseDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DemoDatabase"), b => b.MigrationsAssembly("FindHouseAndT.Infrastructure"));
            });
            builder.Services.AddIdentity<UserApp, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<FindHouseDbContext>()
            .AddDefaultTokenProviders();
            builder.Services.AddCustomService();
            var app = builder.Build();

            // Seed data Identity
            using (var scop = app.Services.CreateScope())
            {
                var service = scop.ServiceProvider;
                var context = scop.ServiceProvider.GetRequiredService<FindHouseDbContext>();
                try
                {
                    context.Database.Migrate();
                    await SeedDataIdentity.SeedAsync(service);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
