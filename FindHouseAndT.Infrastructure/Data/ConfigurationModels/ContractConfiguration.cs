using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouseAndT.Infrastructure.Data.ConfigurationModels
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(x => x.ContractId);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.StatusCustomer).HasColumnType("varchar(200)");
            builder.Property(x => x.StatusHouseOwner).HasColumnType("varchar(200)");
            builder.HasOne(x => x.Customer).WithMany(x => x.Contracts).HasForeignKey(x => x.IdCustomer).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
