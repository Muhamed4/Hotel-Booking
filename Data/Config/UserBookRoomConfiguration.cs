using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class UserBookRoomConfiguration : IEntityTypeConfiguration<UserBookRoom>
    {
        public void Configure(EntityTypeBuilder<UserBookRoom> builder)
        {
            builder.HasKey(X => X.ID);

            builder.Property(X => X.CheckIn)
                .HasColumnName("CheckIn")
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(X => X.CheckOut)
                .HasColumnName("CheckOut")
                .HasColumnType("DATE")
                .IsRequired();

            builder.HasOne(X => X.User)
                .WithMany(X => X.UserBookRooms)
                .HasPrincipalKey(X => X.Id)
                .HasForeignKey(X => X.UserID)
                .HasConstraintName("FK_USERBOOKROOM_BOOK_USER")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(X => X.Room)
                .WithMany(X => X.UserBookRooms)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.RoomID)
                .HasConstraintName("FK_USERBOOKROOM_BOOK_ROOM")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "UserBookRooms", schema: "HotelBooking");
        }
    }
}