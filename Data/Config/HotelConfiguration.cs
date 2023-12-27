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
        }
    }
}