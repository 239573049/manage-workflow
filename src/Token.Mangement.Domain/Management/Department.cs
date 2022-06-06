using Token.Management.Domain.Management.AccessFunction;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Management;

public class Department : AggregateRoot<Guid>, ISoftDelete,IHasCreationTime
{
    /// <summary>
    ///     部门名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     部门编号
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    ///     父级id
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    ///     序号
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    ///     公司id
    /// </summary>
    public Guid CompanyId { get; set; }

    public Company? Company { get; set; }

    public List<UserDepartmentFunction> UserDepartmentFunction { get; set; } = new();

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }
}
