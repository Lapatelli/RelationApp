using RelationApp.Core.Interfaces.Repositories;
using RelationApp.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using RelationApp.Core.Shared;

namespace RelationApp.Infrastructure.Repositories
{
    public class RelationRepository : GenericRepository<Relation>, IRelationRepository
    {
        public RelationRepository(RelationDBContext context) : base(context) { }

        public async Task<Relation> GetRelationByIdAsync(Guid? relationId)
        {
            var entity = await DbSet.Where(r => !r.IsDisabled).Include(r => r.RelationAddress)
                .FirstOrDefaultAsync(r => r.Id == relationId);

            return entity;
        }

        public async Task<IEnumerable<Relation>> GetSortedRelationsInCertainCategoryAsync(Guid? categoryId, string propertyForSorting, bool descending)
        {
            IQueryable<Relation> query = categoryId != null
                ? DbSet.Where(x => !x.IsDisabled).Include(x => x.RelationAddress)
                    .Include(x => x.RelationCategory).Where(x => x.RelationCategory.CategoryId == categoryId)
                : DbSet.Where(x => !x.IsDisabled).Include(x => x.RelationAddress);

            query = SortingDynamic.SortDynamically(query, propertyForSorting, descending);

            var entitiesSorted = await query.ToListAsync();

            return entitiesSorted;
        }
    }
}
