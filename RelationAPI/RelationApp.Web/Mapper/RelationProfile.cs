using AutoMapper;
using RelationApp.Core.Entities;
using RelationApp.Web.ViewModels;


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
        }
    }
}
