using Microsoft.AspNetCore.Authorization;
using RealEstateProject.Localization;
using Volo.Abp.Application.Services;

namespace RealEstateProject;

/* Inherit your application services from this class.
 */
[Authorize]
public abstract class RealEstateProjectAppService : ApplicationService
{
    protected RealEstateProjectAppService()
    {
        LocalizationResource = typeof(RealEstateProjectResource);
    }
}
