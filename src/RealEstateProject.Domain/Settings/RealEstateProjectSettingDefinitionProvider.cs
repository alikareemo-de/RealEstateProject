using Volo.Abp.Settings;

namespace RealEstateProject.Settings;

public class RealEstateProjectSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(RealEstateProjectSettings.MySetting1));
    }
}
