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
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(X => X.LaundryFacility)
                .HasColumnName("LaundryFacility")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(X => X.NoSmoking)
                .HasColumnName("NoSmoking")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(X => X.FreeWifi)
                .HasColumnName("FreeWifi")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(X => X.FreeBreakfast)
                .HasColumnName("FreeBreakfast")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(X => X.AirportTransfer)
                .HasColumnName("AirportTransfer")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(X => X.FontDesk247)
                .HasColumnName("FontDesk247")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(X => X.Restaurant)
                .HasColumnName("Restaurant")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(X => X.AirCondition)
                .HasColumnName("AirCondition")
                .HasColumnType("BIT")
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}