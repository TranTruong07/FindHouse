using Amazon.S3;
using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Infrastructure.Data.SeedData;
using FindHouseAndT.Models.Entities;
using FindHouseAndT.Models.MailKit;
using FindHouseAndT.WebApp.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            // Config Authentication 
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/CustomerPages/CommonView/UserManager";
                options.AccessDeniedPath = "/CustomerPages/CommonView/AccessDenied";
            });
            // Setting mail service
            var mailSetting = builder.Configuration.GetSection("MailSettings");
            builder.Services.Configure<MailSetting>(mailSetting);
            // Add Custom DI Config
            builder.Services.AddCustomService();

            // Configure external login (Google, Facebook)
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddGoogle(option =>
            {
                option.ClientId = builder.Configuration["Authen:Google:ClientId"];
                option.ClientSecret = builder.Configuration["Authen:Google:ClientSecret"];
            })
            .AddFacebook(option =>
            {
                option.AppId = builder.Configuration["Authen:Facebook:AppId"];
                option.AppSecret = builder.Configuration["Authen:Facebook:AppSecret"];
            });


            // AWS Configure
            builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
            builder.Services.AddAWSService<IAmazonS3>();

            var app = builder.Build();
            // Seed data Identity
            using (var scop = app.Services.CreateScope())
            {
                var service = scop.ServiceProvider;
                var context = scop.ServiceProvider.GetRequiredService<FindHouseDbContext>();
                var _db = scop.ServiceProvider.GetRequiredService<FindHouseDbContext>();
                try
                {
                    context.Database.Migrate();
                    await SeedDataIdentity.SeedAsync(service, _db);
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
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/CustomerPages/CommonView/Index");
                }
                else
                {
                    await next(context);
                }
            });
            app.MapRazorPages();
            app.Run();
        }
    }
}
