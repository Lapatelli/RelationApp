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

        public async Task<IEnumerable<Relation>> GetSortedRelationsByCategotyIdAsync(Guid? categoryId, string propertyForSorting, bool descending)
        {
            var relationsSorted = await _unitOfWork.RelationRepository.GetSortedRelationsInCertainCategoryAsync(categoryId, propertyForSorting, descending);

            return relationsSorted;
        }

        public async Task<Relation> CreateRelationAsync(Relation relation,RelationAddress relationAddress, RelationCategory relationCategory)
        {
            var postalCodeFormat = await _unitOfWork.CountryRepository.GetPostalCodeByCountryName(relationAddress.CountryName);

            var relationAddressPostalCode = postalCodeFormat != null
                ? _relationAddressService.TransormPostalCode(relationAddress.PostalCode, postalCodeFormat.PostalCodeFormat)
                : relationAddress.PostalCode;

            relationAddress.PostalCode = relationAddressPostalCode;

            var relationCreated = await _unitOfWork.RelationRepository.AddAsync(relation);
            await _unitOfWork.RelationAddressRepository.AddAsync(relationAddress);
            await _unitOfWork.RelationCategoryRepository.AddAsync(relationCategory);

            await _unitOfWork.CommitAsync();

            return relationCreated;
        }

        public async Task<Relation> UpdateRelationById(Relation relation, RelationAddress relationAddress)
        {
            var relationForUpdate = await _unitOfWork.RelationRepository.GetRelationByIdAsync(relation.Id);
            var relationAddressForUpdate = await _unitOfWork.RelationAddressRepository.GetAddressByRelationIdAsync(relation.Id);
            var postalCodeFormat = await _unitOfWork.CountryRepository.GetPostalCodeByCountryName(relationAddressForUpdate.CountryName);

            relationForUpdate.FullName = relation.FullName;
            relationForUpdate.TelephoneNumber = relation.TelephoneNumber;
            relationForUpdate.EmailAddress = relation.EmailAddress;
            relationForUpdate.ModifiedAt = relation.ModifiedAt;

            relationAddressForUpdate.CountryName = relationAddress.CountryName;
            relationAddressForUpdate.City = relationAddress.City;
            relationAddressForUpdate.Street = relationAddress.Street;
            relationAddressForUpdate.Number = relationAddress.Number;
            relationAddressForUpdate.PostalCode = postalCodeFormat != null
                ? _relationAddressService.TransormPostalCode(relationAddress.PostalCode, postalCodeFormat.PostalCodeFormat)
                : relationAddress.PostalCode;


            _unitOfWork.RelationRepository.Update(relationForUpdate);
            _unitOfWork.RelationAddressRepository.Update(relationAddressForUpdate);

            await _unitOfWork.CommitAsync();

            return relationForUpdate;
        }

        public async Task DeleteCertainRelationsByMakingDisabled(IEnumerable<Relation> relations)
        {
            foreach (var relation in relations)
            {
                var relationToDisable = await _unitOfWork.RelationRepository.GetRelationByIdAsync(relation.Id);

                relationToDisable.ModifiedAt = relation.ModifiedAt;
                relationToDisable.IsDisabled = true;

                _unitOfWork.RelationRepository.Update(relationToDisable);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
