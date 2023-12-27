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
            builder.HasKey(X => new { X.UserID, X.HotelID });

            builder.Property(X => X.Like)
                .HasColumnName("Like")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}