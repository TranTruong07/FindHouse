using FindHouseAndT.Infrastructure.Data.AppDbContext;
using FindHouseAndT.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FindHouseAndT.Infrastructure.Data.SeedData
{
    public class SeedDataIdentity
    {
        private static string role = "Landlord";
        private static Guid Id = new Guid("76a4b731-37d6-488e-9c22-619407bd5ae3");
        private static string Name = "Motel's Own";
        private static string Email = "motel@gmail.com";
        private static string PassWord = "Truong123@";

		public static async Task SeedAsync(IServiceProvider serviceProvider, [FromServices] FindHouseDbContext _db)
        {
            var roleManage = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManage = serviceProvider.GetRequiredService<UserManager<UserApp>>();
            if(!await roleManage.RoleExistsAsync(role)) {
                await roleManage.CreateAsync(new IdentityRole<Guid> { Id = new Guid(), Name = role });
            }

            if(userManage.Users.All(u => u.Email != Email))
            {
                var user = new UserApp
                {
                    Id = Id,
                    UserName = Email,
                    Email = Email,
                    EmailConfirmed = true,
                };
                var result = await userManage.CreateAsync(user, PassWord);
                if(result.Succeeded)
                {
                    await userManage.AddToRoleAsync(user, role);
                    HouseOwner houseOwner = new HouseOwner()
                    {
                        Name = Name,
                        IdHouseOwner = user.Id,
					};
                    _db.HouseOwners.Add(houseOwner);
                    _db.SaveChanges();
				}
                else
                {
                    foreach(var error in result.Errors)
                    {
                        await Console.Out.WriteLineAsync(error.Description.ToString());
                    }
                }
                
            }
        }
    }
}
