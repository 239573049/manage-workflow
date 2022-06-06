using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Management;

/// <summary>
///     公司
/// </summary>
public class Company : AggregateRoot<Guid>, ISoftDelete,IHasCreationTime
{
    /// <summary>
    ///     公司名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     公司编号
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    ///     公司Logo
    /// </summary>
    public string? Logo { get; set; }

    /// <summary>
    ///     描述
    /// </summary>
    public string? Describe { get; set; }

    public List<Department> Department { get; set; } = new();

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }
}
