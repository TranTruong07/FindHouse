using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouseAndT.Infrastructure.Data.ConfigurationModels
{
    public class HouseOwnerConfiguration : IEntityTypeConfiguration<HouseOwner>
    {
        public void Configure(EntityTypeBuilder<HouseOwner> builder)
        {
            builder.HasKey(x => x.IdHouseOwner);
            builder.HasMany(x => x.Motels).WithOne(x => x.HouseOwner).HasForeignKey(x => x.IdHouseOwner);
        }
    }
}
