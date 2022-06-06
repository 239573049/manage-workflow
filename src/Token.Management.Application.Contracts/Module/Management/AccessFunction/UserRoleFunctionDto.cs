using Token.Management.Application.Contracts.Module.Users;

namespace Token.Management.Application.Contracts.Module.Management.AccessFunction;

public class UserRoleFunctionDto
{
    public Guid Id { get; set; }
    public Guid UserInfoId { get; set; }
    public Guid RoleId { get; set; }
    public RoleDto? Role { get; set; }
    public UserInfoDto? UserInfo { get; set; }
}
