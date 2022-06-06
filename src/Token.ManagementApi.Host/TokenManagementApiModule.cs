using Token.HttpApi;
using Token.Management.Application;
using Token.Management.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Token.ManagementApi.Host;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TokenHttpApiModule),
    typeof(TokenManagementEntityFrameworkCoreModule),
    typeof(TokenManagementApplicationModule),
    typeof(AbpAspNetCoreModule)
)]
public class TokenManagementApiModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        IApplicationBuilder? app = context.GetApplicationBuilder();

        app.UseAuditing();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }
}
