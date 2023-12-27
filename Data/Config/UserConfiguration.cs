using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(X => X.ID);

            builder.Property(X => X.Email)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.Password)
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.LastName)
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(X => X.Image)
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired(false);

            builder.HasMany(X => X.UserReactions)
                .WithMany(X => X.HotelReactions)
                .UsingEntity<UserReactHotel>(
                    X => X.HasOne(X => X.Hotel)
                        .WithMany(X => X.UserReactHotels)
                        .HasPrincipalKey(X => X.ID)
                        .HasForeignKey(X => X.HotelID)
                        .HasConstraintName("FK_HOTEL_USER_REACT_HOTEL")
                        .OnDelete(DeleteBehavior.Cascade),

                    X => X.HasOne(X => X.User)
                        .WithMany(X => X.UserReactHotels)
                        .HasPrincipalKey(X => X.ID)
                        .HasForeignKey(X => X.UserID)
                        .HasConstraintName("FK_USER_USER_REACT_HOTEL")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            builder.HasMany(X => X.OwnHotels)
                .WithOne(X => X.User)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.UserID)
                .HasConstraintName("FK_USER_HOTEL")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "Users", schema: "HotelBooking");
        }
    }
}