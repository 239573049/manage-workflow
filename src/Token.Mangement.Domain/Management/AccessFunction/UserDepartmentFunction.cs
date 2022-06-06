using Token.Management.Domain.Users;
using Volo.Abp;
using Volo.Abp.Auditing;

namespace Token.Management.Domain.Management.AccessFunction;

/// <summary>
///     用户部门配置
/// </summary>
public class UserDepartmentFunction : ISoftDelete,IHasCreationTime
{
    public Guid UserInfoId { get; set; }

    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public UserInfo? UserInfo { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreationTime { get; }
}
