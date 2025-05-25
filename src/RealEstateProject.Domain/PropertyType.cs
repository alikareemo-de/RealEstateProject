using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject
{
    // Lookup Tables (Aggregate Roots)
    public class PropertyType : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
