using Token.Management.Application.Contracts.Module.WorkFlow;
using Token.Management.Domain.WorkFlow;

namespace Token.Management.Application.Contracts.AppServices.WorkFlow;

public interface IWorkflowTemplateService
{
    /// <summary>
    ///     创建模板
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    Task<WorkflowTemplateDto> CreateWorkflowTemplate(WorkflowTemplateDto workflow);

    /// <summary>
    ///     获取模板
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<(List<WorkflowTemplateDto>, int)> GetWorkflowTemplatePage(string? name, int pageNo = 1, int pageSize = 20);

    /// <summary>
    ///     删除模板
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteWorkflowTemplate(Guid id);

    /// <summary>
    ///     编辑模板
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    Task UpdateWorkflowTemplate(WorkflowTemplateDto workflow);

    /// <summary>
    ///     获取模板节点配置
    /// </summary>
    /// <param name="workflowId"></param>
    /// <returns></returns>
    Task<List<WorkflowNodeTemplateDto>> GetWorkflowNodeTemplates(Guid workflowId);

    /// <summary>
    ///     获取节点已存在角色
    /// </summary>
    /// <param name="workflowNodeId"></param>
    /// <returns></returns>
    Task<List<Guid>> GetWorkflowNodeRoleIds(Guid workflowNodeId);

    /// <summary>
    ///     添加节点角色
    /// </summary>
    /// <param name="workflowNodeId"></param>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    Task CreateWorkflowNodeRole(Guid workflowNodeId, List<Guid> roleIds);

    /// <summary>
    ///     编辑模板节点
    /// </summary>
    /// <param name="workflowNodeTemplate"></param>
    /// <returns></returns>
    Task UpdateWorkflowNodeTemplate(WorkflowNodeTemplateDto workflowNodeTemplate);

    /// <summary>
    ///     删除模板节点
    /// </summary>
    /// <param name="workflowNodeId"></param>
    /// <returns></returns>
    Task DeleteWorkflowNodeTemplate(Guid workflowNodeId);

    /// <summary>
    ///     添加模板节点
    /// </summary>
    /// <param name="templateDto"></param>
    /// <returns></returns>
    Task<WorkflowNodeTemplateDto> CreateWorkflowNodeTemplate(WorkflowNodeTemplateDto templateDto);

    /// <summary>
    ///     编辑模板节点审批顺序
    /// </summary>
    /// <param name="workflows"></param>
    /// <returns></returns>
    Task<List<WorkflowNodeTemplateDto>> UpdateWorkflowNodeTemplateIndex(List<WorkflowNodeTemplateDto> workflows);

    /// <summary>
    ///     编辑模板节点顺序统一接口
    /// </summary>
    /// <param name="workflows"></param>
    /// <returns></returns>
    void UpdateWorkflowNodeTemplateHandleIndex(List<WorkflowNodeTemplate> workflows);

    /// <summary>
    ///     获取所有模板
    /// </summary>
    /// <returns></returns>
    Task<List<WorkflowTemplateDto>> GetWorkflowTemplatesAll();

    /// <summary>
    ///     获取下一节点id如果不存在就返回null
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Guid?> GetsTheNextNode(Guid id);

    /// <summary>
    ///     获取模板的节点数据
    /// </summary>
    /// <param name="workTemplateId"></param>
    /// <returns></returns>
    Task<List<WorkflowNodeTemplateDto>> GetWorkflowNodeTemplateList(Guid workTemplateId);

    /// <summary>
    ///     获取模板节点和节点下所有用户
    /// </summary>
    /// <param name="workTemplateId"></param>
    /// <returns></returns>
    Task<List<WorkflowNodeRoleUserInfoDto>> GetWorkflowNodeRoleUserInfoDto(Guid workTemplateId);

    /// <summary>
    ///     判断当前人是否可以审批当前节点
    /// </summary>
    /// <param name="nodeTemplateId"></param>
    /// <returns></returns>
    Task<bool> IsExamineAndApprove(Guid nodeTemplateId);

    /// <summary>
    ///     获取当前模板节点id
    /// </summary>
    /// <param name="workflowTemplateCode"></param>
    /// <param name="nodeId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<Guid?> GetObtainingTemplateNode(string workflowTemplateCode, Guid? nodeId, Guid userId);

    /// <summary>
    ///     删除模板
    /// </summary>
    /// <param name="templateId"></param>
    /// <returns></returns>
    Task DeleteTemplate(Guid templateId);
}
