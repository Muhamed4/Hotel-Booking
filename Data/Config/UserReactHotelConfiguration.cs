using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class UserReactHotelConfiguration : IEntityTypeConfiguration<UserReactHotel>
    {
        public void Configure(EntityTypeBuilder<UserReactHotel> builder)
        {
            builder.HasKey(X => X.ID);

            builder.HasOne(X => X.Hotel)
                .WithMany(X => X.UserReactHotels)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.HotelID)
                .HasConstraintName("FK_HOTEL_USErREACTHotels")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "UserReactHotels", schema: "HotelBooking");
        }
    }
}