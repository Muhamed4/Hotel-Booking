using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class UserWatchHotelConfiguration : IEntityTypeConfiguration<UserWatchHotel>
    {
        public void Configure(EntityTypeBuilder<UserWatchHotel> builder)
        {
            builder.HasKey(X => X.ID);

            builder.HasOne(X => X.Hotel)
                .WithMany(X => X.UserWatchHotels)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.HotelID)
                .HasConstraintName("FK_HOTEL_USErWATCHHotels")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "UserWatchHotels", schema: "HotelBooking");
        }
    }
}