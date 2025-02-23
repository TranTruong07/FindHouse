using FindHouseAndT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouseAndT.Infrastructure.Data.ConfigurationModels
{
    public class BookRequestConfiguration : IEntityTypeConfiguration<BookRequest>
    {
        public void Configure(EntityTypeBuilder<BookRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Customer).WithMany(x => x.BookRequests).HasForeignKey(x => x.IdCustomer).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Room).WithMany(x => x.BookRequests).HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
