using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouseAndT.Infrastructure.Data.ConfigurationModels
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.IdOrder);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Status).HasColumnType("varchar(200)");
            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.IdCustomer).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.HouseOwner).WithMany(x => x.Orders).HasForeignKey(x => x.IdHouseOwner).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Motel).WithMany(x => x.Orders).HasForeignKey(x => x.IdMotel).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Room).WithMany(x => x.Orders).HasForeignKey(x => x.IdRoom).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
