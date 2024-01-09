using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(X => X.ID);

            builder.Property(X => X.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.HasOne(X => X.Feature)
                .WithMany(X => X.Services)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.FeatureID)
                .HasConstraintName("FK_FEATURE_SERVICE")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "Services", schema: "HotelBooking");
        }
    }
}