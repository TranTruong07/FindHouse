using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouseAndT.Infrastructure.Data.ConfigurationModels
{ 
    public class MotelConfiguration : IEntityTypeConfiguration<Motel>
    {
        public void Configure(EntityTypeBuilder<Motel> builder)
        {
            builder.HasKey(x => x.IdMotel);
            builder.HasOne(x => x.HouseOwner).WithMany(x => x.Motels).HasForeignKey(x => x.IdHouseOwner).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Rooms).WithOne(x => x.Motel).HasForeignKey(x => x.IdMotel).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Orders).WithOne(x => x.Motel).HasForeignKey(x => x.IdMotel).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
