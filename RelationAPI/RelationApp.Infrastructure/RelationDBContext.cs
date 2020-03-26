using Microsoft.EntityFrameworkCore;
using RelationApp.Infrastructure.Configurations;
using RelationApp.Core.Entities;

namespace RelationApp.Infrastructure
{
    public partial class RelationDBContext : DbContext
    {
        public RelationDBContext(DbContextOptions<RelationDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<AddressType> TblAddressType { get; set; }
        public virtual DbSet<Category> TblCategory { get; set; }
        public virtual DbSet<Country> TblCountry { get; set; }
        public virtual DbSet<Relation> TblRelation { get; set; }
        public virtual DbSet<RelationAddress> TblRelationAddress { get; set; }
        public virtual DbSet<RelationCategory> TblRelationCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.ApplyConfiguration(new RelationAddressConfiguration());

            modelBuilder.ApplyConfiguration(new RelationCategoryConfiguration());

            modelBuilder.ApplyConfiguration(new RelationConfiguration());
        }
    }
}
