using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelationApp.Core.Entities;

namespace RelationApp.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("tblCategory");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Code1)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Code2)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Code3)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Code4)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Code5)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Code6)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedAt).HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Timestamp1).HasColumnType("datetime");

            builder.Property(e => e.Timestamp2).HasColumnType("datetime");

            builder.Property(e => e.Timestamp3).HasColumnType("datetime");

            builder.Property(e => e.Timestamp4).HasColumnType("datetime");
        }
    }
}
