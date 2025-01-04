using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouseAndT.Infrastructure.Data.ConfigurationModels
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasIndex(x => x.RoomCode).IsUnique();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Status).HasColumnType("varchar(200)");
            builder.HasOne(x => x.Motel).WithMany(x => x.Rooms).HasForeignKey(x => x.IdMotel).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Orders).WithOne(x => x.Room).HasForeignKey(x => x.IdRoom).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.BookRequests).WithOne(x => x.Room).HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
