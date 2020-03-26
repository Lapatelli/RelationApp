﻿using System;

namespace RelationApp.Web.ViewModels
{
    public class GetAllRelationsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetNumber { get; set; }
    }
}
