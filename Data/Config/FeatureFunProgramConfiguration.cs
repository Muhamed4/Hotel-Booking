using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Booking.Data.Config
{
    public class FeatureFunProgramConfiguration : IEntityTypeConfiguration<FeatureFunProgram>
    {
        public void Configure(EntityTypeBuilder<FeatureFunProgram> builder)
        {
            builder.HasKey(X => new { X.FeatureID, X.Description });

            builder.Property(X => X.Description)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.HasOne(X => X.Feature)
                .WithMany(X => X.FeatureFunPrograms)
                .HasPrincipalKey(X => X.ID)
                .HasForeignKey(X => X.FeatureID)
                .HasConstraintName("FK_FEATURE_FUNPROGRAM")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(name: "FeatureFunPrograms", schema: "HotelBooking");
        }
    }
}