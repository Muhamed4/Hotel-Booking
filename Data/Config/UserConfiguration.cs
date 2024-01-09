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
            builder.HasKey(X => X.Id);

            // builder.Property(X => X.Email)
            //     .HasColumnName("Email")
            //     .HasColumnType("NVARCHAR")
            //     .HasMaxLength(250);

            // builder.Property(X => X.Password)
            //     .HasColumnName("Password")
            //     .HasColumnType("NVARCHAR(MAX)")
            //     .IsRequired();

            // builder.Property(X => X.UserName)
            //     .HasColumnName("UserName")
            //     .HasColumnType("NVARCHAR(MAX)");

            builder.Property(X => X.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(X => X.LastName)
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();

            builder.Property(X => X.Image)
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR(MAX)");

            
            builder.HasIndex(X => X.Email, "EmailUnique").IsUnique();

            // builder.HasMany(X => X.UserReactions)
            //     .WithMany(X => X.HotelReactions)
            //     .UsingEntity<UserReactHotel>(
            //         X => X.HasOne(X => X.Hotel)
            //             .WithMany(X => X.UserReactHotels)
            //             .HasPrincipalKey(X => X.ID)
            //             .HasForeignKey(X => X.HotelID)
            //             .HasConstraintName("FK_HOTEL_USER_REACT_HOTEL")
            //             .OnDelete(DeleteBehavior.Cascade),

            //         X => X.HasOne(X => X.User)
            //             .WithMany(X => X.UserReactHotels)
            //             .HasPrincipalKey(X => X.ID)
            //             .HasForeignKey(X => X.UserID)
            //             .HasConstraintName("FK_USER_USER_REACT_HOTEL")
            //             .OnDelete(DeleteBehavior.Cascade)
            //     );

            // builder.HasMany(X => X.OwnHotels)
            //     .WithOne(X => X.User)
            //     .HasPrincipalKey(X => X.ID)
            //     .HasForeignKey(X => X.UserID)
            //     .HasConstraintName("FK_USER_HOTEL")
            //     .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(X => X.UserReactHotels)
                .WithOne(X => X.User)
                .HasPrincipalKey(X => X.Id)
                .HasForeignKey(X => X.UserID)
                .HasConstraintName("FK_USER_USER_REACT_HOTEL")
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasMany(X => X.UserWatchHotels)
                .WithOne(X => X.User)
                .HasPrincipalKey(X => X.Id)
                .HasForeignKey(X => X.UserID)
                .HasConstraintName("FK_USER_USER_WATCH_HOTEL")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "Users", schema: "HotelBooking");
        }
    }
}