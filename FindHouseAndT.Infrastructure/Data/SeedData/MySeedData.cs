using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FindHouseAndT.Infrastructure.Data
{
    public static class MySeedData
    {
        private static string role1 = "Landlord";
        private static string role2 = "Customer";
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> { Id = new Guid("cd03f5c2-7993-45ff-8fd5-d908649d2e56"), Name = role1, NormalizedName = role1.ToUpper()},
                new IdentityRole<Guid> { Id = new Guid("f80df872-715b-49af-bf57-65ebf5ef6c11"), Name = role2, NormalizedName = role2.ToUpper()}
                );
        }
    }
}
