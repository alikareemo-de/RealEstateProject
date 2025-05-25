using RealEstateProject.Enums;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace RealEstateProject.Entites
{
    // Property Aggregate Root
    public class Property : AggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Area { get; set; }
        public int NumberOfRooms { get; set; }
        public TransactionType TransactionType { get; set; }
        public int ViewCount { get; set; }

        // Relationships
        public Guid PropertyTypeId { get; set; }
        public Guid GovernorateId { get; set; }
        public Guid AgentId { get; set; }

        // Navigation Properties
        public PropertyType PropertyType { get; set; }
        public Governorate Governorate { get; set; }
        public Agent Agent { get; set; }

        // Collections
        public ICollection<PropertyFeature> Features { get; set; } = new List<PropertyFeature>();
        public ICollection<PropertyAmenity> Amenities { get; set; } = new List<PropertyAmenity>();
        public ICollection<PropertyNearbyPlace> NearbyPlaces { get; set; } = new List<PropertyNearbyPlace>();
        public ICollection<PropertyMedia> Media { get; set; } = new List<PropertyMedia>();
    }
}
