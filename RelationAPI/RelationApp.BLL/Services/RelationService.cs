using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using RelationApp.Core.Interfaces.Services;
using RelationApp.Core.Interfaces;
using RelationApp.Core.Entities;
using System.Linq;

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
            var relationCreated = await _unitOfWork.RelationRepository.AddAsync(relation);


            var postalCodeFormat = await _unitOfWork.CountryRepository.GetPostalCodeByCountryName(relationAddress.CountryName);
            var relationAddressPostalCode = _relationAddressService.TransormPostalCode(relationAddress.PostalCode, postalCodeFormat.PostalCodeFormat);
            relationAddress.PostalCode = relationAddressPostalCode;

            await _unitOfWork.RelationAddressRepository.AddAsync(relationAddress);

            await _unitOfWork.RelationCategoryRepository.AddAsync(relationCategory);

            await _unitOfWork.CommitAsync();

            return relationCreated;
        }

        public async Task<IEnumerable<Relation>> GetSortedRelationsByCategotyIdAsync(Guid? categoryId,string sortedProp, bool descending)
        {
            var relationsByCategory = categoryId != null
                ? await _unitOfWork.RelationRepository.GetRelationWithAddressByCategoryAsync(categoryId)
                : await _unitOfWork.RelationRepository.GetRelationWithAddressAsync();

            var sortedRelations = Sorting(relationsByCategory, sortedProp, descending);

            return sortedRelations;
        }

        public IEnumerable<Relation> Sorting(IEnumerable<Relation> entities, string sortedProp, bool descending)
        {
            Func<Relation, object> sortedFunc = (relation) =>
            {
                if (string.IsNullOrEmpty(sortedProp))
                {
                    object o = typeof(Relation).GetProperty(sortedProp) != null
                        ? relation
                        : (object)relation.RelationAddress;

                    return GetSortedValue(o, sortedProp);
                }

                return relation.Name;
            };

            var result = descending 
                ? entities.OrderByDescending(sortedFunc).ToList()
                : entities.OrderBy(sortedFunc).ToList();

            return result;

            object GetSortedValue(object obj, string propName) => obj.GetType().GetProperty(propName).GetValue(obj);
        }
    }
}
