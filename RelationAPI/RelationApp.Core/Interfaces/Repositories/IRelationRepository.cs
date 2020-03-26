using RelationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Repositories
{
    public interface IRelationRepository : IGenericRepository<Relation>
    {
        Task<IEnumerable<Relation>> GetRelationWithAddressAsync();

        Task<IEnumerable<Relation>> GetRelationWithAddressByCategoryAsync(Guid? categoryId);

        Task<IEnumerable<Relation>> GetSortedRelationWithAddressByCategoryAsync(Guid? categoryId, string sortedProp,bool ascending);
    }
}
