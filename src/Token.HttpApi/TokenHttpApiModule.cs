﻿using System.Text;
using CSRedis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Token.HttpApi.filters;
using Token.HttpApi.Module;
using Token.Management.Domain.Shared;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Token.HttpApi;

public class TokenHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureAuthentication(context, context.Services.GetConfiguration());
        ConfigureCors(context, context.Services.GetConfiguration());
        ConfigureRedis(context);
        ConfigureSwaggerServices(context);
        ConfigurationMvc(context);
    }

    private void ConfigurationMvc(ServiceConfigurationContext context)
    {
        context.Services.AddMvc(o =>
            {
                o.Filters.Add(typeof(GlobalExceptionsFilter), 1);
                o.Filters.Add(typeof(GlobalResponseFilter), 1);
                o.Filters.Add(typeof(GlobalModelStateValidationFilter), 1);
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
    }

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context)
    {
        context.Services.AddSwaggerGen(o =>
        {
            string[] files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml"); //获取api文档
            string[] array = files;
            foreach (string filePath in array)
            {
                o.IncludeXmlComments(filePath, true);
            }

            o.SwaggerDoc("v1", new OpenApiInfo { Title = "GoYes API", Version = "v1" });
            o.DocInclusionPredicate((docName, description) => true);
            o.CustomSchemaIds(type => type.FullName);
            o.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme }
                    },
                    Array.Empty<string>()
                }
            });
            o.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "请输入文字“Bearer”，后跟空格和JWT值，格式  : Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
        });
    }

    private static void ConfigureRedis(ServiceConfigurationContext context)
    {
        string? configuration = context.Services.GetConfiguration()["Redis:Configuration"];
        RedisHelper.Initialization(new CSRedisClient(configuration));
    }

    private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
    {
        IConfigurationSection? configurationSection = configuration.GetSection(nameof(TokenOptions));
        TokenOptions? tokenOptions = configurationSection.Get<TokenOptions>();
        if (string.IsNullOrEmpty(tokenOptions.Issuer))
        {
            throw new Exception("未设置JWT权限配置");
        }

        context.Services.Configure<TokenOptions>(configurationSection);
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, //是否在令牌期间验证签发者
                    ValidateAudience = true, //是否验证接收者
                    ValidateLifetime = true, //是否验证失效时间
                    ValidateIssuerSigningKey = true, //是否验证签名
                    ValidAudience = tokenOptions.Audience, //接收者
                    ValidIssuer = tokenOptions.Issuer, //签发者，签发的Token的人
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecretKey!))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // 添加signalr的token 因为signalr的token在请求头上所以需要设置
                        StringValues accessToken = context.Request.Query["access_token"];
                        PathString path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments(HubConstants.Chat))
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
                };
            });
    }

    private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        context.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        IApplicationBuilder? app = context.GetApplicationBuilder();
        IWebHostEnvironment? env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "GoYes API");

                options.RoutePrefix = string.Empty;
            });
        }

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("CorsPolicy");

        app.UseAuthentication();
        app.UseAuthorization();

    }
}
