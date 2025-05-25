using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject.Entites
{
    public class NearbyPlace : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public ICollection<PropertyNearbyPlace> Properties { get; set; } = new List<PropertyNearbyPlace>();
    }
}
