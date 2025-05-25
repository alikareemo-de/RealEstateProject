using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace RealEstateProject.Data;

/* This is used if database provider does't define
 * IRealEstateProjectDbSchemaMigrator implementation.
 */
public class NullRealEstateProjectDbSchemaMigrator : IRealEstateProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
