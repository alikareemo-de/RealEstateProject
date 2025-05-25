using System;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject
{
    public class PropertyMedia : Entity<Guid>
    {
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
        public string MediaType { get; set; } // image / video
        public string Url { get; set; }
    }
}
