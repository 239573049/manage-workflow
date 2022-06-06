using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Management.AccessFunction;

/// <summary>
/// 角色菜单配置
/// </summary>
public class MenuRoleFunction : AggregateRoot<Guid>,ISoftDelete,IHasCreationTime
{
    /// <inheritdoc />
    public MenuRoleFunction()
    {
    }

    ///<inheritdoc />
    public MenuRoleFunction(Guid id):base(id)
    {
    }

    /// <summary>
    ///
    /// </summary>
    public Guid MenuId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    ///
    /// </summary>
    public virtual Menu? Menu { get; set; }

    /// <summary>
    ///
    /// </summary>
    public virtual Role? Role { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; set; }
}
