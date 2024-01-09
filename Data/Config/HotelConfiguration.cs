using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(X => X.ID);

            builder.Property(X => X.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.Country)
                .HasColumnName("Country")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.City)
                .HasColumnName("City")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.Image)
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            // builder.HasMany(X => X.HotelWatches)
            //     .WithMany(X => X.UserWatchs)
            //     .UsingEntity<UserWatchHotel>(
            //         X => X.HasOne(X => X.User)
            //             .WithMany(X => X.UserWatchHotels)
            //             .HasPrincipalKey(X => X.ID)
            //             .HasForeignKey(X => X.UserID)
            //             .HasConstraintName("FK_USER_USERWATCHHOTELS")
            //             .OnDelete(DeleteBehavior.Cascade),

            //         x => x.HasOne(X => X.Hotel)
            //             .WithMany(X => X.UserWatchHotels)
            //             .HasPrincipalKey(X => X.ID)
            //             .HasForeignKey(X => X.HotelID)
            //             .HasConstraintName("FK_HOTEL_USERWATCHHOTELS")
            //             .OnDelete(DeleteBehavior.Cascade)
            //     );


            builder.HasMany(X => X.Rooms)
                .WithOne(X => X.Hotel)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.HotelID)
                .HasConstraintName("FK_HOTEL_ROOMS")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(X => X.Reviews)
                .WithOne(X => X.Hotel)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.HotelID)
                .HasConstraintName("FK_HOTEL_REVIEWS")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "Hotels", schema: "HotelBooking");
        }
    }
}