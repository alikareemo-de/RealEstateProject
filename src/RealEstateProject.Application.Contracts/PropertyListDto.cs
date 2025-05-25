using System;

namespace RealEstateProject
{
    public class PropertyListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Area { get; set; }
    }
}
