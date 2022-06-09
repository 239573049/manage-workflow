using Token.Infrastructure;
using Token.Management.Application.Contracts;
using Token.Management.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Token.Management.Application;

[DependsOn(typeof(TokenManagementApplicationContractsModule),
    typeof(TokenInfrastructureModule),
    typeof(TokenManagementEntityFrameworkCoreModule),
    typeof(AbpAutoMapperModule))]
public class TokenManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<TokenManagementApplicationModule>();

            options.AddProfile<MapperProfile>();
        } );
    }
}
