using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstateProject.Data;
using Volo.Abp.DependencyInjection;

namespace RealEstateProject.EntityFrameworkCore;

public class EntityFrameworkCoreRealEstateProjectDbSchemaMigrator
    : IRealEstateProjectDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreRealEstateProjectDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the RealEstateProjectDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<RealEstateProjectDbContext>()
            .Database
            .MigrateAsync();
    }
}
