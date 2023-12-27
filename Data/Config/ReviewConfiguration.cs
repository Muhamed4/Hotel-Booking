using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(X => X.ID);

            builder.Property(X => X.Rating)
                .HasColumnName("Rating")
                .HasColumnType("decimal")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(X => X.Comment)
                .HasColumnName("Comment")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.Date)
                .HasColumnName("Date")
                .HasColumnType("DATETIME2(3)")
                .IsRequired();
        }
    }
}