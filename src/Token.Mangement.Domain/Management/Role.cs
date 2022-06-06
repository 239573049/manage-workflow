using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Management;

/// <summary>
/// 角色表
/// </summary>
public class Role : AggregateRoot<Guid>, ISoftDelete,IHasCreationTime
{
    /// <inheritdoc />
    public Role()
    {
    }

    /// <inheritdoc />
    public Role(Guid id) : base(id)
    {
    }

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

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; set; }

}
