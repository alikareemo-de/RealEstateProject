using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RealEstateProject.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class RealEstateProjectDbContextFactory : IDesignTimeDbContextFactory<RealEstateProjectDbContext>
{
    public RealEstateProjectDbContext CreateDbContext(string[] args)
    {
        RealEstateProjectEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<RealEstateProjectDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new RealEstateProjectDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../RealEstateProject.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
