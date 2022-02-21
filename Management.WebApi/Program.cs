using Autofac;
using Autofac.Extensions.DependencyInjection;
using Management.WebCore.Filters;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using static Management.WebCore.Swagger.SwaggerExtend;

var builder = WebApplication.CreateBuilder(args);

var service=builder.Services;
service.AddSingleton(new AppSettings(builder.Environment.ContentRootPath));
service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
RedisHelper.Initialization(new CSRedisClient(AppSettings.App("Redis:Connect")));//redis����
service.AddSignalR().AddRedis(AppSettings.App("Redis:Connect"));
service.AddControllers();
service.AddSwaggerSetup("v1", "����ϵͳApi�ĵ�", "Management.WebApi", new Contact { Email = "239573049@qq.com", Name = "XiaoHu", Url = new Uri("https://gitee.com/hejiale010426") });
service.AddEndpointsApiExplorer();
service.AddAutoMapper(new List<Assembly> { Assembly.Load("Management.Application")});
service.AddCors(delegate (CorsOptions options)
{
    options.AddPolicy("CorsPolicy", corsBuilder =>
    {
        corsBuilder.SetIsOriginAllowed((string _) => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});
service.AddControllers(o =>
{
    o.Filters.Add(typeof(GlobalExceptionsFilter));
    o.Filters.Add(typeof(GlobalResponseFilter));
    o.Filters.Add(typeof(GlobalModelStateValidationFilter));
});

#region ����ע��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());//�������ڴ��������ṩ�ߵĹ���
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>//����ע��
{
    var basePath = AppDomain.CurrentDomain.BaseDirectory;
    var servicesDllFile = Path.Combine(basePath, "Management.Application.dll");//��Ҫ����ע�����Ŀ���ɵ�dll�ļ�����
    var repositoryDllFile = Path.Combine(basePath, "Management.Repository.dll");
    var assemblysServices = Assembly.LoadFrom(servicesDllFile);
    containerBuilder.RegisterAssemblyTypes(assemblysServices)
        .Where(x => x.FullName != null && x.FullName.EndsWith("Service"))//�Ա���������Ƿ���ͬȻ��ע��
              .AsImplementedInterfaces()
              .InstancePerDependency();
    var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
    containerBuilder.RegisterAssemblyTypes(assemblysRepository)
        .Where(x => x.FullName != null && x.FullName.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .InstancePerDependency();

});
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management.WebApi");
        c.DocExpansion(DocExpansion.None);
        c.DefaultModelsExpandDepth(-1);
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("CorsPolicy");//CORS strategy
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
await app.RunAsync();
