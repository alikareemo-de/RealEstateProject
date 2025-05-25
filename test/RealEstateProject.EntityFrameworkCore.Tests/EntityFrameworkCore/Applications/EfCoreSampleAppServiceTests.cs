using RealEstateProject.Samples;
using Xunit;

namespace RealEstateProject.EntityFrameworkCore.Applications;

[Collection(RealEstateProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<RealEstateProjectEntityFrameworkCoreTestModule>
{

}
