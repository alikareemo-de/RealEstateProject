using Microsoft.Extensions.Localization;
using RealEstateProject.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace RealEstateProject;

[Dependency(ReplaceServices = true)]
public class RealEstateProjectBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<RealEstateProjectResource> _localizer;

    public RealEstateProjectBrandingProvider(IStringLocalizer<RealEstateProjectResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
