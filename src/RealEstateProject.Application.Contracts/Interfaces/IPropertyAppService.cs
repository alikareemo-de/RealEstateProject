using RealEstateProject.Dtos;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace RealEstateProject.Interfaces
{
    public interface IPropertyAppService : ICrudAppService<
   PublicPropertyDto,
   Guid,
   PagedAndSortedResultRequestDto,
   CreateUpdatePropertyDto>
    {
    }
}
