using Token.Management.Application.Contracts.Module.Users;

namespace Token.Management.Application.Contracts.Module.Management.AccessFunction;

/// <summary>
///     用户部门配置
/// </summary>
public class UserDepartmentFunctionDto
{
    public Guid Id { get; set; }
    public Guid UserInfoId { get; set; }
    public Guid DepartmentId { get; set; }
    public DepartmentDto? Department { get; set; }
    public UserInfoDto? UserInfo { get; set; }
}
