using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(X => X.ID);

            builder.Property(X => X.FreeParking)
                .HasColumnName("FreeParking")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.Property(X => X.LaundryFacility)
                .HasColumnName("LaundryFacility")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.Property(X => X.NoSmoking)
                .HasColumnName("NoSmoking")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.Property(X => X.FreeWifi)
                .HasColumnName("FreeWifi")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.Property(X => X.FreeBreakfast)
                .HasColumnName("FreeBreakfast")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.Property(X => X.AirportTransfer)
                .HasColumnName("AirportTransfer")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.Property(X => X.FontDesk247)
                .HasColumnName("FontDesk247")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.Property(X => X.Restaurant)
                .HasColumnName("Restaurant")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.Property(X => X.AirCondition)
                .HasColumnName("AirCondition")
                .HasColumnType("BIT")
                .HasDefaultValueSql("(0)");

            builder.HasOne(X => X.Hotel)
                .WithMany(X => X.Features)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.HotelID)
                .HasConstraintName("FK_HOTEL_FEATURES")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "Features", schema: "HotelBooking");
        }
    }
}