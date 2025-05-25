using RealEstateProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace RealEstateProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(RealEstateProjectEntityFrameworkCoreModule),
    typeof(RealEstateProjectApplicationContractsModule)
    )]
public class RealEstateProjectDbMigratorModule : AbpModule
{
}
