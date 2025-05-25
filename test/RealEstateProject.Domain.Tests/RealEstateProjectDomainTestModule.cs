using Volo.Abp.Modularity;

namespace RealEstateProject;

[DependsOn(
    typeof(RealEstateProjectDomainModule),
    typeof(RealEstateProjectTestBaseModule)
)]
public class RealEstateProjectDomainTestModule : AbpModule
{

}
