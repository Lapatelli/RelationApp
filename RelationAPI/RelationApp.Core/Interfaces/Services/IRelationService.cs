using RelationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Services
{
    public interface IRelationService
    {
        Task<IEnumerable<Relation>> GetSortedRelationsByCategotyIdAsync(Guid? categoryId, string sortedProp, bool descending);

        Task<Relation> CreateRelationAsync(Relation relation,RelationAddress relationAddress, RelationCategory relationCategory);

        IEnumerable<Relation> Sorting(IEnumerable<Relation> entities, string sortedProp, bool descending);
    }
}
