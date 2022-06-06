using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore;

[DependsOn(
    typeof(AbpEntityFrameworkCoreMySQLModule)
)]
public class TokenManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<TokenDbContext>(x =>
        {
            x.AddDefaultRepositories(true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL();
        });
    }
}
