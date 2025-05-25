using Xunit;

namespace RealEstateProject.EntityFrameworkCore;

[CollectionDefinition(RealEstateProjectTestConsts.CollectionDefinitionName)]
public class RealEstateProjectEntityFrameworkCoreCollection : ICollectionFixture<RealEstateProjectEntityFrameworkCoreFixture>
{

}
