using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelationApp.Core.Entities;

namespace RelationApp.Infrastructure.Configurations
{
    public class RelationCategoryConfiguration : IEntityTypeConfiguration<RelationCategory>
    {
        public void Configure(EntityTypeBuilder<RelationCategory> builder)
        {
            builder.ToTable("tblRelationCategory");

            builder.HasKey(e => e.CategoryId);

            builder.HasOne(e => e.Relation).WithOne(e => e.RelationCategory);

            builder.HasOne(e => e.Category).WithOne(e => e.RelationCategory);
        }
    }
}
