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
        private readonly IRelationAddressService _relationAddressService;

        public RelationService(IUnitOfWork unitOfWork, IRelationAddressService relationAddressService)
        {
            _unitOfWork = unitOfWork;
            _relationAddressService = relationAddressService;
        }

        public async Task<Relation> CreateRelationAsync(Relation relation,RelationAddress relationAddress, RelationCategory relationCategory)
        {
            var postalCodeFormat = await _unitOfWork.CountryRepository.GetPostalCodeByCountryName(relationAddress.CountryName);

            var relationAddressPostalCode = _relationAddressService.TransormPostalCode(relationAddress.PostalCode, postalCodeFormat.PostalCodeFormat);
            relationAddress.PostalCode = relationAddressPostalCode;

            var relationCreated = await _unitOfWork.RelationRepository.AddAsync(relation);

            await _unitOfWork.RelationAddressRepository.AddAsync(relationAddress);

            await _unitOfWork.RelationCategoryRepository.AddAsync(relationCategory);

            await _unitOfWork.CommitAsync();

            return relationCreated;
        }

        public async Task<IEnumerable<Relation>> GetSortedRelationsByCategotyIdAsync(Guid? categoryId, string sortedProp, bool descending)
        {
            var sortedRelations = await _unitOfWork.RelationRepository.GetSortedRelationsInCertainCategoryAsync(categoryId, sortedProp, descending);

            return sortedRelations;
        }
    }
}
