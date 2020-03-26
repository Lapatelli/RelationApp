using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using RelationApp.Core.Interfaces.Services;
using RelationApp.Core.Interfaces;
using RelationApp.Core.Entities;

namespace RelationApp.BLL.Services
{
    public class RelationService : IRelationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RelationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Relation>> GetAllRelationsAsync()
        {
            var relations = await _unitOfWork.RelationRepository.GetRelationWithAddressAsync();

            return relations;
        }

        public async Task<IEnumerable<Relation>> GetRelationsByCategotyIdAsync(Guid? categoryId)
        {
            var relationsByCategory = await _unitOfWork.RelationRepository.GetRelationWithAddressByCategoryAsync(categoryId);

            return relationsByCategory;
        }

        public async Task<IEnumerable<Relation>> GetSortedRelationsByCategotyIdAsync(Guid? categoryId,string sortedProp, bool ascending)
        {
            var sortedRelationsByCategory = await _unitOfWork.RelationRepository.GetSortedRelationWithAddressByCategoryAsync(categoryId, sortedProp, ascending);

            return sortedRelationsByCategory;
        }
    }
}
