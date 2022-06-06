namespace Token.Management.Application.Contracts.Module.Management.AccessFunction;

/// <summary>
///     角色菜单配置
/// </summary>
public class MenuRoleFunctionDto
{
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public Guid RoleId { get; set; }
    public MenuDto? Menu { get; set; }
    public RoleDto? Role { get; set; }
}
