using RealEstateProject.Enums;
using System;

namespace RealEstateProject.Dtos
{
    public class PublicPropertyDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Area { get; set; }
        public int? NumberOfRooms { get; set; }
        public TransactionType TransactionType { get; set; }
        public int? ViewCount { get; set; }
        public Guid? PropertyTypeId { get; set; }
        public Guid? GovernorateId { get; set; }
        public Guid? AgentId { get; set; }
        public string? PropertyTypeName { get; set; }
        public string? GovernorateName { get; set; }
        public string? AgentCompanyName { get; set; }
    }

}
