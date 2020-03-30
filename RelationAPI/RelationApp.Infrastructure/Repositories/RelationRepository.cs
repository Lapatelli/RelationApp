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
        public RelationRepository(RelationDBContext context) : base(context) { }

        public async Task<IEnumerable<Relation>> GetRelationsByCategoryAsync(Guid? categoryId)
        {
            var entities = categoryId != null
                ? await DbSet.Include(x => x.RelationCategory).Where(x => x.RelationCategory.CategoryId == categoryId)
                    .Include(x => x.RelationAddress).ToListAsync()
                : await DbSet.Include(x => x.RelationAddress).ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<Relation>> GetSortedRelationsInCertainCategoryAsync(Guid? categoryId, string sortedProp, bool descending)
        {
            IQueryable<Relation> query = DbSet.Include(x => x.RelationAddress);

            Func<Relation, object> sortedFunc = (relation) =>
            {
                if (!string.IsNullOrEmpty(sortedProp))
                {
                    object o = typeof(Relation).GetProperty(sortedProp) != null
                        ? relation
                        : (object)relation.RelationAddress;

                    return GetSortedValue(o, sortedProp);
                }

                return relation.Name;
            };

            if (categoryId != null)
            {
                query = descending
                    ? query.Include(x => x.RelationCategory).Where(x => x.RelationCategory.CategoryId == categoryId)
                        .OrderByDescending(sortedFunc).AsQueryable()
                    : query.Include(x => x.RelationCategory).Where(x => x.RelationCategory.CategoryId == categoryId)
                        .OrderBy(sortedFunc).AsQueryable();
            }
            else
            {
                query = descending
                    ? query.OrderByDescending(sortedFunc).AsQueryable()
                    : query.OrderBy(sortedFunc).AsQueryable();
            }

            var sortedEntities = await query.ToListAsync();
            
            return sortedEntities;

            object GetSortedValue(object obj, string propName) => obj.GetType().GetProperty(propName).GetValue(obj);
        }
    }
}
