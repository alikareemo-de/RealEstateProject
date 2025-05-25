using System;

namespace RealEstateProject
{
    public class PropertyFilterDto
    {
        public Guid? GovernorateId { get; set; }
        public Guid? PropertyTypeId { get; set; }
        public TransactionType? TransactionType { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinArea { get; set; }
        public decimal? MaxArea { get; set; }
    }
}
