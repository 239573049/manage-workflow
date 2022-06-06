using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Application.Contracts.Module.WorkFlow;

namespace Token.Management.Application.Contracts.AppServices.WorkFlow;

public interface IWorkflowInstanceService
{
    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="workflow"></param>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    Task<WorkflowInstanceDto> CreateWorkflowInstance(CreateWorkflowInstanceDto workflow, UserInfoDto userInfo);
}
