using System.Threading.Tasks;

namespace RealEstateProject.Data;

public interface IRealEstateProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
