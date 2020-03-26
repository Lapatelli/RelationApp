using RelationApp.Core.Interfaces.Repositories;
using RelationApp.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace RelationApp.Infrastructure.Repositories
{
    public class RelationRepository : GenericRepository<Relation>, IRelationRepository
    {
        public RelationRepository(RelationDBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Relation>> GetRelationWithAddressAsync()
        {
            var entities = await DbSet.Include(x => x.RelationAddress).ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<Relation>> GetRelationWithAddressByCategoryAsync(Guid? categoryId)
        {
            var entities = await DbSet.Include(x => x.RelationCategory).Where(x=>x.RelationCategory.CategoryId == categoryId)
                                      .Include(x => x.RelationAddress).ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<Relation>> GetSortedRelationWithAddressByCategoryAsync(Guid? categoryId, string sortedProp,bool ascending)
        {
            var entities = categoryId != null ? await GetRelationWithAddressByCategoryAsync(categoryId) : await GetRelationWithAddressAsync();

            var sortedEntities = Sorting(entities, sortedProp, ascending);

            return sortedEntities;
        }

        public override IEnumerable<Relation> Sorting(IEnumerable<Relation> entities, string sortedProp, bool ascending)
        {
            var propertyInfo = typeof(Relation).GetProperty(sortedProp);

            try
            {
                var result = ascending ? entities.OrderBy(sort => propertyInfo.GetValue(sort)).ToList() :
                                         entities.OrderByDescending(sort => propertyInfo.GetValue(sort)).ToList();

                return result;
            }
            catch (NullReferenceException)
            {
                var result = ascending ? entities.OrderBy(sort => sort.RelationAddress.GetType().GetProperty(sortedProp).GetValue(sort.RelationAddress)).ToList() :
                                        entities.OrderByDescending(sort => sort.RelationAddress.GetType().GetProperty(sortedProp).GetValue(sort.RelationAddress)).ToList();

                return result;
            }
        }
    }
}
