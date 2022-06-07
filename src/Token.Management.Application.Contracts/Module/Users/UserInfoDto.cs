using Token.Management.Application.Contracts.Module.Management;
using Token.Management.Domain.Base;
using Token.Management.Domain.Shared;

namespace Token.Management.Application.Contracts.Module.Users;

public class UserInfoDto : SerialNumberEntity
{
    public Guid Id { get; set; }

    /// <summary>
    ///     账号
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    ///     密码
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    ///     微信关联id
    /// </summary>
    public string? WXOpenId { get; set; }

    /// <summary>
    ///     昵称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     头像
    /// </summary>
    public string? HeadPortraits { get; set; }

    /// <summary>
    ///     性别
    /// </summary>
    public sbyte Sex { get; set; }

    /// <summary>
    ///     账号状态
    /// </summary>
    public StatusEnum Status { get; set; }

    /// <summary>
    /// 状态描述
    /// </summary>
    public string? StatusName { get; set; }

    /// <summary>
    ///     性别
    /// </summary>
    public string? SexName { get; set; }

    /// <summary>
    ///     手机号
    /// </summary>
    public long? MobileNumber { get; set; }

    /// <summary>
    ///     邮箱
    /// </summary>
    public string? EMail { get; set; }

    public List<DepartmentDto> Department { get; set; } = new();
    public List<RoleDto> Role { get; set; } = new();
}
