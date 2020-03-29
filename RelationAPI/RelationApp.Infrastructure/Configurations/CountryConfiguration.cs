using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelationApp.Core.Entities;

namespace RelationApp.Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("tblCountry");

            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.RelationAddress).WithOne(e => e.Country);

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Iso31662)
                .HasColumnName("ISO3166_2")
                .HasMaxLength(2)
                .IsUnicode(false);

            builder.Property(e => e.Iso31663)
                .HasColumnName("ISO3166_3")
                .HasMaxLength(3)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedAt).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.PostalCodeFormat)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
