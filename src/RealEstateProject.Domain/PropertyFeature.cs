using System;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject
{
    public class PropertyFeature : Entity<Guid>
    {
        public Guid PropertyId { get; set; }
        public Guid FeatureId { get; set; }
        public Property Property { get; set; }
        public Feature Feature { get; set; }
    }
}
