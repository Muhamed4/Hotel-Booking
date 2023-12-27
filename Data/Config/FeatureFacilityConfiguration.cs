using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class FeatureFacilityConfiguration : IEntityTypeConfiguration<FeatureFacility>
    {
        public void Configure(EntityTypeBuilder<FeatureFacility> builder)
        {
            builder.HasKey(X => new { X.FeatureID, X.Description });

            builder.Property(X => X.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();
        }
    }
}