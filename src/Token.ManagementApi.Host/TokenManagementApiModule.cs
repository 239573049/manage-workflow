using Token.HttpApi;
using Token.Management.Application;
using Token.Management.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Token.ManagementApi.Host;

/// <summary>
/// Api模块
/// </summary>
[DependsOn(
    typeof(TokenHttpApiModule),
    typeof(AbpAutofacModule),
    typeof(TokenManagementApplicationModule),
    typeof(AbpAspNetCoreModule)
)]
public  class TokenManagementApiModule : AbpModule
{
    /// <summary>
    /// Use
    /// </summary>
    /// <param name="context"></param>
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        IApplicationBuilder? app = context.GetApplicationBuilder();

        app.UseAuditing();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }
}
