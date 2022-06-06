using Token.Management.Domain.Base;

namespace Token.Management.Application.Contracts.Module.Management;

/// <summary>
///     角色
/// </summary>
public class RoleDto : SerialNumberEntity
{
    public Guid Id { get; set; }

    /// <summary>
    ///     名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     编号
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    ///     备注
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    ///     排序
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    ///     父级
    /// </summary>
    public Guid? ParentId { get; set; }
}
