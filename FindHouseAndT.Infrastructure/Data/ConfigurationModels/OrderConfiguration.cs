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
        }
    }
}
