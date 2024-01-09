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
                .HasColumnType("DECIMAL(10, 2)")
                .IsRequired();

            builder.Property(X => X.Comment)
                .HasColumnName("Comment")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.Date)
                .HasColumnName("Date")
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.HasOne(X => X.User)
                .WithMany(X => X.Reviews)
                .HasPrincipalKey(X => X.Id)
                .HasForeignKey(X => X.UserID)
                .HasConstraintName("FK_USER_REVIEWS")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "Reviews", schema: "HotelBooking");
        }
    }
}