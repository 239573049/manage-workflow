using Token.Management.Domain.Users;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Token.Management.Domain.Management.AccessFunction;

/// <summary>
///     用户部门配置
/// </summary>
public class UserDepartmentFunction : AggregateRoot<Guid>, ISoftDelete, IHasCreationTime
{
    /// <inheritdoc />
    public UserDepartmentFunction()
    {
    }

    /// <inheritdoc />
    public UserDepartmentFunction(Guid id) : base(id)
    {
    }

    public Guid UserInfoId { get; set; }

    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public UserInfo? UserInfo { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; set; }
}
