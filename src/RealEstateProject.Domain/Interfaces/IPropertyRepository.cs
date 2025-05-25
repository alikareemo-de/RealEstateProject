using RealEstateProject.Dtos;
using RealEstateProject.Entites;
using RealEstateProject.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstateProject.Interfaces
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetListAsync(
            Guid? governorateId = null,
            Guid? propertyTypeId = null,
            TransactionType? transactionType = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            decimal? minArea = null,
            decimal? maxArea = null);
        Task<PublicPropertyDto?> GetByIdAsync(Guid id);
        Task<List<PublicPropertyDto>> GetSimilarPropertiesAsync(Guid propertyId);
    }
}
