using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace RealEstateProject
{
    // Agent Aggregate Root
    public class Agent : AggregateRoot<Guid>
    {
        public IdentityUser User { get; set; } // ABP Identity reference
        public Guid UserId { get; set; } // ABP Identity reference
        public string LicenseNumber { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsProfileComplete { get; set; }

        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
