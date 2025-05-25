using Asp.Versioning;
using RealEstateProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RealEstateProject.Controllers;

/* Inherit your controllers from this class.
 */
[ApiVersion("1.0")]

public abstract class RealEstateProjectController : AbpControllerBase
{
    protected RealEstateProjectController()
    {
        LocalizationResource = typeof(RealEstateProjectResource);
    }
}
