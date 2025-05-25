using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace RealEstateProject
{
    public interface IPublicPropertyAppService : IApplicationService
    {
        Task<List<PropertyListDto>> FilteredSearchAsync(PropertyFilterDto input);
    }
}
