using Token.Management.Domain.Users;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Management.AccessFunction;

/// <summary>
///     用户角色配置
/// </summary>
public class UserRoleFunction : AggregateRoot<Guid>, ISoftDelete, IHasCreationTime
{
    public Guid UserInfoId { get; set; }

    public Guid RoleId { get; set; }

    public Role? Role { get; set; }

    public UserInfo? UserInfo { get; set; }

    public DateTime CreationTime { get; }

    public bool IsDeleted { get; set; }
}
