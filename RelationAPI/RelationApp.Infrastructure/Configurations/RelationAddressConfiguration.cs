using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelationApp.Core.Entities;

namespace RelationApp.Infrastructure.Configurations
{
    public class RelationAddressConfiguration : IEntityTypeConfiguration<RelationAddress>
    {
        public void Configure(EntityTypeBuilder<RelationAddress> builder)
        {
            builder.ToTable("tblRelationAddress");

            builder.HasKey(e=>e.RelationId);

            builder.HasOne(e => e.Relation).WithOne(e => e.RelationAddress);

            builder.Property(e => e.Building)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.NumberSuffix)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PostalCode)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Province)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
