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
            builder.HasKey(X => new { X.UserID, X.HotelID });

            builder.Property(X => X.WatchCount)
                .HasColumnName("WatchCount")
                .HasColumnType("INT")
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}