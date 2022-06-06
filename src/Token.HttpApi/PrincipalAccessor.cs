﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Token.HttpApi.Module;
using Token.Management.Domain;
using Token.Management.Domain.Users;
using Volo.Abp.DependencyInjection;

namespace Token.HttpApi;

public class PrincipalAccessor : IPrincipalAccessor, ITransientDependency
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly TokenOptions _tokenOptions;

    private readonly string _xTenantId = Constants.TenantHeader;

    public PrincipalAccessor(IHttpContextAccessor contextAccessor, IOptions<TokenOptions> tokenOptions)
    {
        _contextAccessor = contextAccessor;
        _tokenOptions = tokenOptions.Value;
    }

    public string Name => _contextAccessor.HttpContext.User.Identity?.Name ?? string.Empty;

    public Guid ID => Guid.Parse(GetClaimValueByType(Constants.ClaimKey).FirstOrDefault() ?? Guid.Empty.ToString());

    public bool? IsAuthenticated()
    {
        return _contextAccessor.HttpContext.User.Identity?.IsAuthenticated;
    }

    public string GetToken()
    {
        return _contextAccessor.HttpContext.Request.Headers[Constants.JwtHeader].ToString()
            .Replace(Constants.JwtType, "");
    }

    public IEnumerable<Claim> GetClaimsIdentity()
    {
        return _contextAccessor.HttpContext.User.Claims;
    }

    public List<string> GetClaimValueByType(string claimType)
    {
        return GetClaimsIdentity().Where(item => item.Type == claimType).Select(item => item.Value).ToList();
    }

    public List<string> GetUserInfoFromToken(string claimType)
    {
        JwtSecurityTokenHandler securityTokenHandler = new();
        string token = GetToken();
        return !string.IsNullOrEmpty(token)
            ? securityTokenHandler.ReadJwtToken(token).Claims.Where(item => item.Type == claimType)
                .Select(item => item.Value).ToList()
            : new List<string>();
    }

    public string GetUser(string token)
    {
        JwtSecurityTokenHandler securityTokenHandler = new();
        return securityTokenHandler.ReadJwtToken(token).Claims.Where(item => item.Type == Constants.User)
            .Select(item => item.Value).FirstOrDefault() ?? "";
    }

    public string GetTenantId()
    {
        HttpContext? httpContext = _contextAccessor.HttpContext;
        return httpContext != null && httpContext.Request.Headers.ContainsKey(_xTenantId)
            ? httpContext.Request.Headers[_xTenantId].FirstOrDefault()
            : null;
    }

    public Guid UserId()
    {
        Guid user = ID;
        if (user == Guid.Empty)
        {
            throw new BusinessException(401, "账号未授权");
        }

        return user;
    }

    public T GetUserInfo<T>()
    {
        string result = GetClaimValueByType(Constants.User).FirstOrDefault() ??
                        throw new BusinessException(401, "账号未授权");
        return JsonConvert.DeserializeObject<T>(result);
    }

    public Task<string> CreateTokenAsync<T>(T userInfo)
    {
        var user = userInfo as UserInfo;

        // 添加一些需要的键值对
        Claim[] claims = { new Claim(Constants.User, JsonConvert.SerializeObject(userInfo)) };
        if (user != null)
        {
            claims.AddFirst(new Claim(Constants.Role,JsonConvert.SerializeObject(user.UserRoleFunction.Select(x=>x.RoleId))));
        }

        byte[] keyBytes = Encoding.UTF8.GetBytes(_tokenOptions.SecretKey!);
        SigningCredentials cred = new(new SymmetricSecurityKey(keyBytes),
            SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new(
            _tokenOptions.Issuer, // 签发者
            _tokenOptions.Audience, // 接收者
            claims, // payload
            expires: DateTime.Now.AddMinutes(_tokenOptions.ExpireMinutes), // 过期时间
            signingCredentials: cred); // 令牌
        string? token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return Task.FromResult(token);
    }
}
