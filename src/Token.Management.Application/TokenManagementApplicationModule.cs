using Token.Management.Application.Contracts;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Token.Management.Application;

[DependsOn(typeof(TokenManagementApplicationContractsModule),
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
