using Microsoft.AspNetCore.Authorization;
using RealEstateProject.Dtos;
using RealEstateProject.Interfaces;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace RealEstateProject.Properties
{
    [Authorize]
    public class PropertyAppService : CrudAppService<
     Property,
     PublicPropertyDto,
     Guid,
     PagedAndSortedResultRequestDto,
     CreateUpdatePropertyDto>,
     IPropertyAppService
    {
        public PropertyAppService(IRepository<Property, Guid> repository)
            : base(repository)
        {
        }

    }
}
