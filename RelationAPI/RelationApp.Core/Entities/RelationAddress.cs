﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RelationApp.Core.Entities
{
    public partial class RelationAddress
    {
        public Guid RelationId { get; set; }
        public Relation Relation { get; set; }
        public Guid AddressTypeId { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string NumberSuffix { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Building { get; set; }
        public string PostalCode { get; set; }
        public Country Country { get; set; }
        public Guid? CountryId { get; set; }
        public string CountryName { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
