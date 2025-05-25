using RealEstateProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RealEstateProject.Permissions;

public class RealEstateProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(RealEstateProjectPermissions.GroupName);
        var group = context.AddGroup("RealEstate");

        group.AddPermission(RealEstateProjectPermissions.Agent);
        group.AddPermission(RealEstateProjectPermissions.Visitor);
        group.AddPermission(RealEstateProjectPermissions.PropertyManagement);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(RealEstateProjectPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RealEstateProjectResource>(name);
    }
}
