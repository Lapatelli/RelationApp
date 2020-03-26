using RelationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Services
{
    public interface IRelationService
    {
        Task<IEnumerable<Relation>> GetAllRelationsAsync();

        Task<IEnumerable<Relation>> GetRelationsByCategotyIdAsync(Guid? categoryId);

        Task<IEnumerable<Relation>> GetSortedRelationsByCategotyIdAsync(Guid? categoryId, string sortedProp, bool ascending);
    }
}
