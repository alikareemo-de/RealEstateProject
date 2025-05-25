using RealEstateProject.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateProject.Dtos
{
    public class CreateUpdatePropertyDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public decimal Area { get; set; }

        public int NumberOfRooms { get; set; }

        public TransactionType TransactionType { get; set; }

        public Guid PropertyTypeId { get; set; }
        public Guid GovernorateId { get; set; }
        public Guid AgentId { get; set; }
    }
}
