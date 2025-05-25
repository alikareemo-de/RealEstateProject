using System;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject.Entites
{
    public class PropertyNearbyPlace : Entity<Guid>
    {
        public Guid PropertyId { get; set; }
        public Guid NearbyPlaceId { get; set; }
        public Property Property { get; set; }
        public NearbyPlace NearbyPlace { get; set; }
    }
}
