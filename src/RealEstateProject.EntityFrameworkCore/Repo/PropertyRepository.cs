using Microsoft.EntityFrameworkCore;
using RealEstateProject.Dtos;
using RealEstateProject.Entites;
using RealEstateProject.EntityFrameworkCore;
using RealEstateProject.Enums;
using RealEstateProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;


namespace RealEstateProject.Repo
{
    public class PropertyRepository : EfCoreRepository<RealEstateProjectDbContext, Property, Guid>, IPropertyDataSource
    {
        private readonly IDbContextProvider<RealEstateProjectDbContext> _dbContextProvider;

        public PropertyRepository(IDbContextProvider<RealEstateProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
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
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var results = await dbContext
                .Set<Property>()
                .FromSqlInterpolated($@"
                EXEC SearchProperties
                @GovernorateId = {governorateId},
                @PropertyTypeId = {propertyTypeId},
                @TransactionType = {(transactionType.HasValue ? (int)transactionType.Value : (int?)null)},
                @MinPrice = {minPrice},
                @MaxPrice = {maxPrice},
                @MinArea = {minArea},
                @MaxArea = {maxArea}
                ")
                .ToListAsync();

            return results;
        }

        public async Task<PublicPropertyDto?> GetByIdAsync(Guid id)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            return await dbContext.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.Governorate)
                .Include(p => p.Agent)
                .Where(p => p.Id == id)
                .Select(p => new PublicPropertyDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    Area = p.Area,
                    NumberOfRooms = p.NumberOfRooms,
                    TransactionType = p.TransactionType,
                    ViewCount = p.ViewCount,
                    PropertyTypeId = p.PropertyTypeId,
                    PropertyTypeName = p.PropertyType.Name,
                    GovernorateId = p.GovernorateId,
                    GovernorateName = p.Governorate.Name,
                    AgentId = p.AgentId,
                    AgentCompanyName = p.Agent.CompanyName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<PublicPropertyDto>> GetSimilarPropertiesAsync(Guid propertyId)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();

            var currentProperty = await dbContext.Properties.FindAsync(propertyId);

            if (currentProperty == null)
                return new List<PublicPropertyDto>();

            var query = dbContext.Properties
                .Include(p => p.PropertyType)
                .Include(p => p.Governorate)
                .Include(p => p.Agent)
                .Where(p =>
                    p.Id != propertyId &&
                    p.PropertyTypeId == currentProperty.PropertyTypeId &&
                    p.GovernorateId == currentProperty.GovernorateId &&
                    p.TransactionType == currentProperty.TransactionType)
                .OrderByDescending(p => p.ViewCount)
                .Take(5);

            return await query.Select(p => new PublicPropertyDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Area = p.Area,
                NumberOfRooms = p.NumberOfRooms,
                TransactionType = p.TransactionType,
                ViewCount = p.ViewCount,
                PropertyTypeId = p.PropertyTypeId,
                PropertyTypeName = p.PropertyType.Name,
                GovernorateId = p.GovernorateId,
                GovernorateName = p.Governorate.Name,
                AgentId = p.AgentId,
                AgentCompanyName = p.Agent.CompanyName
            }).ToListAsync();
        }
    }
}
