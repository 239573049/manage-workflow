using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Management.AccessFunction;

/// <summary>
///     角色菜单配置
/// </summary>
public class MenuRoleFunction : AggregateRoot<Guid>,ISoftDelete,IHasCreationTime
{
    public Guid MenuId { get; set; }

    public Guid RoleId { get; set; }

    public Menu? Menu { get; set; }

    public Role? Role { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }
}
