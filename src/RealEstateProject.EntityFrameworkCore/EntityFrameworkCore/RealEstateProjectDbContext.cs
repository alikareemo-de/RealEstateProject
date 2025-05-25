using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace RealEstateProject.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class RealEstateProjectDbContext :
    AbpDbContext<RealEstateProjectDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    public DbSet<Agent> Agents { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Governorate> Governorates { get; set; }
    public DbSet<NearbyPlace> NearbyPlaces { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyAmenity> PropertyAmenities { get; set; }
    public DbSet<PropertyFeature> PropertyFeatures { get; set; }
    public DbSet<PropertyMedia> PropertyMedias { get; set; }
    public DbSet<PropertyNearbyPlace> PropertyNearbyPlaces { get; set; }
    public DbSet<PropertyType> PropertyTypes { get; set; }


    #endregion

    public RealEstateProjectDbContext(DbContextOptions<RealEstateProjectDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        // Property Relationships
        builder.Entity<Property>(b =>
        {
            // One-to-Many
            b.HasOne(p => p.PropertyType)
             .WithMany(pt => pt.Properties)
             .HasForeignKey(p => p.PropertyTypeId);

            b.HasOne(p => p.Governorate)
             .WithMany(g => g.Properties)
             .HasForeignKey(p => p.GovernorateId);

            b.HasOne(p => p.Agent)
             .WithMany(a => a.Properties)
             .HasForeignKey(p => p.AgentId);

            // Many-to-Many
            b.HasMany(p => p.Features)
             .WithOne(pf => pf.Property)
             .HasForeignKey(pf => pf.PropertyId);

            b.HasMany(p => p.Amenities)
             .WithOne(pf => pf.Property)
             .HasForeignKey(pf => pf.PropertyId);

            b.HasMany(p => p.NearbyPlaces)
             .WithOne(pf => pf.Property)
             .HasForeignKey(pf => pf.PropertyId);

            b.HasMany(p => p.Media)
             .WithOne(pf => pf.Property)
             .HasForeignKey(pf => pf.PropertyId);
        });

        // Agent-User Relationship
        builder.Entity<Agent>(b =>
        {
            b.HasIndex(a => a.UserId).IsUnique();
            b.HasOne(a => a.User);
        });
    }
}
