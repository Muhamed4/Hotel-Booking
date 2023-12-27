using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(X => X.ID);

            builder.Property(X => X.Price)
                .HasColumnName("Price")
                .HasColumnType("DECIMAL")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(X => X.RoomNumber)
                .HasColumnName("RoomNumber")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(X => X.BedCount)
                .HasColumnName("BedCount")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(X => X.CheckIn)
                .HasColumnName("CheckIn")
                .HasColumnType("DATETIME(3)")
                .IsRequired();

            builder.Property(X => X.CheckOut)
                .HasColumnName("CheckOut")
                .HasColumnType("DATETIME(3)")
                .IsRequired();

            builder.HasOne(X => X.User)
                .WithMany(X => X.BookRooms)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.UserID)
                .HasConstraintName("FK_USER_BOOK_ROOM")
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(name: "Rooms", schema: "HotelBooking");

        }
    }
}