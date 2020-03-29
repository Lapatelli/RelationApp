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
            var entities = await DbSet.Include(x => x.RelationCategory).Where(x => x.RelationCategory.CategoryId == categoryId)
                .Include(x => x.RelationAddress).ToListAsync();

            return entities;
        }
    }
}
