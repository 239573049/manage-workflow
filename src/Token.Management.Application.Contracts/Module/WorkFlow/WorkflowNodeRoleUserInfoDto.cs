using Token.Management.Application.Contracts.Module.Users;

namespace Token.Management.Application.Contracts.Module.WorkFlow;

public class WorkflowNodeRoleUserInfoDto
{
    public Guid Id { get; set; }

    /// <summary>
    ///     节点顺序
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    ///     描述
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    ///     当前节点所有审批用户
    /// </summary>
    public List<UserInfoDto> UserInfo { get; set; } = new();
}
