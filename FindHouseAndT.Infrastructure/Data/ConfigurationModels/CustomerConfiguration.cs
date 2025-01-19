using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouseAndT.Infrastructure.Data.ConfigurationModels
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.IdUser);
            builder.HasOne(x => x.UserApp).WithOne(x => x.Customer).HasForeignKey<Customer>(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Contracts).WithOne(x => x.Customer).HasForeignKey(x => x.IdCustomer).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
