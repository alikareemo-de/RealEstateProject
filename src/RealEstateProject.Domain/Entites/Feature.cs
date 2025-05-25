using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject.Entites
{
    // Feature System
    public class Feature : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public ICollection<PropertyFeature> Properties { get; set; } = new List<PropertyFeature>();
    }
}
