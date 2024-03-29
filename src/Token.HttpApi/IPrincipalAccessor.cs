﻿using System.Security.Claims;
using Token.Management.Domain.Users;

namespace Token.HttpApi;

public interface IPrincipalAccessor
{
    string Name { get; }

    Guid ID { get; }
    UserInfo GetUser(string token);

    bool? IsAuthenticated();

    IEnumerable<Claim> GetClaimsIdentity();

    List<string> GetClaimValueByType(string claimType);

    string GetToken();

    string GetTenantId();

    /// <summary>
    ///     获取账号信息
    /// </summary>
    /// <returns></returns>
    T GetUserInfo<T>();

    /// <summary>
    /// 获取权限列表
    /// </summary>
    /// <returns></returns>
    List<Guid> GetRoleIds();

    List<string> GetUserInfoFromToken(string claimType);

    /// <summary>
    ///     获取用户id （未授权异常401）
    /// </summary>
    /// <returns></returns>
    Guid UserId();

    Task<string> CreateTokenAsync(UserInfo userInfo);
}
