using System;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject
{
    public class PropertyAmenity : Entity<Guid>
    {
        public Guid PropertyId { get; set; }
        public Guid AmenityId { get; set; }
        public Property Property { get; set; }
        public Amenity Amenity { get; set; }
    }
}
