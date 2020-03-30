﻿using RelationApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RelationApp.Core.Interfaces.Repositories
{
    public interface IRelationRepository : IGenericRepository<Relation>
    {
        Task<IEnumerable<Relation>> GetRelationsByCategoryAsync(Guid? categoryId);

        Task<IEnumerable<Relation>> GetSortedRelationsInCertainCategoryAsync(Guid? categoryId, string sortedProp, bool descending);
    }
}
