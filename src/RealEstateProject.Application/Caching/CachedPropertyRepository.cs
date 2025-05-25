using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace RealEstateProject.Caching
{
    public class CachedPropertyRepository : IPropertyRepository
    {
        private readonly IDistributedCache _cache;
        private readonly IPropertyDataSource _dataSource;

        public CachedPropertyRepository(IDistributedCache cache, IPropertyDataSource dataSource)
        {
            _cache = cache;
            _dataSource = dataSource;
        }

        public async Task<List<Property>> GetListAsync(
            Guid? governorateId = null,
            Guid? propertyTypeId = null,
            TransactionType? transactionType = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            decimal? minArea = null,
            decimal? maxArea = null)
        {
            var cacheKey = $"property_list_{governorateId}_{propertyTypeId}_{transactionType}_{minPrice}_{maxPrice}_{minArea}_{maxArea}";
            var cached = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrWhiteSpace(cached))
            {
                return JsonSerializer.Deserialize<List<Property>>(cached);
            }

            var result = await _dataSource.GetListAsync(governorateId, propertyTypeId, transactionType, minPrice, maxPrice, minArea, maxArea);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), options);

            return result;
        }

        public async Task<PublicPropertyDto?> GetByIdAsync(Guid id)
        {
            var cacheKey = $"property_detail_{id}";
            var cached = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrWhiteSpace(cached))
            {
                return JsonSerializer.Deserialize<PublicPropertyDto>(cached);
            }

            var result = await _dataSource.GetByIdAsync(id);

            if (result != null)
            {
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };

                await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), options);
            }

            return result;
        }

        public async Task<List<PublicPropertyDto>> GetSimilarPropertiesAsync(Guid propertyId)
        {
            var cacheKey = $"similar_properties_{propertyId}";
            var cached = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrWhiteSpace(cached))
            {
                return JsonSerializer.Deserialize<List<PublicPropertyDto>>(cached);
            }

            var result = await _dataSource.GetSimilarPropertiesAsync(propertyId);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), options);

            return result;
        }
    }
}
