using System.ComponentModel.DataAnnotations;
using Token.Management.Domain.Management;
using Token.Management.Domain.Management.AccessFunction;
using Token.Management.Domain.Shared;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Users;

public class UserInfo : AggregateRoot<Guid>, ISoftDelete,IHasCreationTime
{
    /// <summary>
    ///     账号
    /// </summary>
    [Required]
    public string? AccountNumber { get; set; }

    /// <summary>
    ///     密码
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    ///     微信关联id
    /// </summary>
    [MaxLength(50)]
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
    public SexEnum Sex { get; set; }

    /// <summary>
    ///     账号状态
    /// </summary>
    public StatueEnum Statue { get; set; }

    /// <summary>
    ///     手机号
    /// </summary>
    [MaxLength(11)]
    public long? MobileNumber { get; set; }

    /// <summary>
    ///     邮箱
    /// </summary>
    public string? EMail { get; set; }

    public virtual List<UserRoleFunction> UserRoleFunction { get; set; } = new();

    public virtual List<UserDepartmentFunction> UserDepartmentFunction { get; set; } = new();

    public virtual List<Department> Department { get; set; } = new();

    public virtual List<MenuRoleFunction> MenuRoleFunction { get; set; } = new();

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }
}
