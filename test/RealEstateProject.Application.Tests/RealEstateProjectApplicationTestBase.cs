using Volo.Abp.Modularity;

namespace RealEstateProject;

public abstract class RealEstateProjectApplicationTestBase<TStartupModule> : RealEstateProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
