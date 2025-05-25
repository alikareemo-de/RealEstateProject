using RealEstateProject.Samples;
using Xunit;

namespace RealEstateProject.EntityFrameworkCore.Domains;

[Collection(RealEstateProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<RealEstateProjectEntityFrameworkCoreTestModule>
{

}
