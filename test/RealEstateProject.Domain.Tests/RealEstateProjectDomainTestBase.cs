using Volo.Abp.Modularity;

namespace RealEstateProject;

/* Inherit from this class for your domain layer tests. */
public abstract class RealEstateProjectDomainTestBase<TStartupModule> : RealEstateProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
