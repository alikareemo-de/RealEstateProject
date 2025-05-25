using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject.Entites
{
    public class Governorate : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
