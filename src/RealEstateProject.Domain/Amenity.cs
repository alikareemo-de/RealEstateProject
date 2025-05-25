using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject
{
    // Repeat similar structure for Amenity and NearbyPlace
    public class Amenity : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public ICollection<PropertyAmenity> Properties { get; set; } = new List<PropertyAmenity>();
    }
}
