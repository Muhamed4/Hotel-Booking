using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class RoomImageConfiguration : IEntityTypeConfiguration<RoomImage>
    {
        public void Configure(EntityTypeBuilder<RoomImage> builder)
        {
            builder.HasKey(X => X.ID);

            builder.Property(X => X.Image)
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();
        }
    }
}