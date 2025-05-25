using Volo.Abp.Modularity;

namespace RealEstateProject;

[DependsOn(
    typeof(RealEstateProjectApplicationModule),
    typeof(RealEstateProjectDomainTestModule)
)]
public class RealEstateProjectApplicationTestModule : AbpModule
{

}
