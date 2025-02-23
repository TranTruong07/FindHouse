using FindHouseAndT.Infrastructure.Data.ConfigurationModels;
using FindHouseAndT.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FindHouseAndT.Infrastructure.Data.AppDbContext
{
    public class FindHouseDbContext : IdentityDbContext<UserApp, IdentityRole<Guid>, Guid>
    {
        public FindHouseDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HouseOwner> HouseOwners { get; set;}
        public DbSet<Motel> Motels { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserApp> UserApps { get; set; }
        public DbSet<BookRequest> BookRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new HouseOwnerConfiguration());
            builder.ApplyConfiguration(new MotelConfiguration());
            builder.ApplyConfiguration(new ContractConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new UserAppConfiguration());
            builder.ApplyConfiguration(new BookRequestConfiguration());
            builder.Seed();
            base.OnModelCreating(builder);
        }

    }
}
