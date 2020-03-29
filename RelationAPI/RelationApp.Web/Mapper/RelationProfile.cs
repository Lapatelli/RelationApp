using AutoMapper;
using RelationApp.Core.Entities;
using RelationApp.Web.ViewModels;
using System;

namespace RelationApp.Web.Mapper
{
    public class RelationProfile : Profile
    {
        public RelationProfile()
        {
            CreateMap<Relation, GetAllRelationsViewModel>()
                .ConvertUsing(src => new GetAllRelationsViewModel
                {
                    Id = src.Id,
                    Name = src.Name,
                    FullName = src.FullName,
                    TelephoneNumber = src.TelephoneNumber,
                    EmailAddress = src.EmailAddress,
                    Country = src.RelationAddress.CountryName,
                    City = src.RelationAddress.City,
                    PostalCode = src.RelationAddress.PostalCode,
                    StreetNumber = src.RelationAddress.Street
                });

            CreateMap<CreateRelationViewModel,Relation>()
                .ConvertUsing(src => new Relation
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    IsDisabled = false,
                    Name = src.Name,
                    FullName = src.FullName,
                    TelephoneNumber = src.TelephoneNumber,
                    EmailAddress = src.EmailAddress
                });

            CreateMap<(CreateRelationViewModel model,Relation relation), RelationAddress>()
                .ConvertUsing(src => new RelationAddress
                {
                    RelationId = src.relation.Id,
                    AddressTypeId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    CountryName = src.model.Country,
                    City = src.model.City,
                    PostalCode = src.model.PostalCode,
                    Street = src.model.StreetNumber
                });

            CreateMap<(Relation relation, Guid categoryId), RelationCategory>()
                .ConvertUsing(src => new RelationCategory
                {
                    RelationId = src.relation.Id,
                    CategoryId = src.categoryId
                });
        }
    }
}
