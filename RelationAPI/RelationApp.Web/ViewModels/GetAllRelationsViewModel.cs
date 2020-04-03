using System;

namespace RelationApp.Web.ViewModels
{
    public class GetRelationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public int? StreetNumber { get; set; }
    }
}
