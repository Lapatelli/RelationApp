using RelationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Services
{
    public interface IRelationService
    {
        Task<IEnumerable<Relation>> GetSortedRelationsByCategotyIdAsync(Guid? categoryId, string propertyForSorting, bool descending);

        Task<Relation> GetRelationByIdAsync(Guid? relationId);

        Task<Relation> CreateRelationAsync(Relation relation,RelationAddress relationAddress, RelationCategory relationCategory);

        Task DeleteCertainRelationsByMakingDisabled(IEnumerable<Relation> relations);

        Task<Relation> UpdateRelationById(Relation relation, RelationAddress relationAddress);
    }
}
