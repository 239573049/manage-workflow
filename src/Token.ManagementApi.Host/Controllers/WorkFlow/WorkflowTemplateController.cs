using Microsoft.AspNetCore.Mvc;
using Token.HttpApi;
using Token.Infrastructure;
using Token.Management.Application.Contracts.AppServices.WorkFlow;
using Token.Management.Application.Contracts.Module.WorkFlow;
using Token.Management.Domain;
using Token.ManagementApi.Host.Module;

namespace Token.ManagementApi.Host.Controllers.WorkFlow;

/// <inheritdoc />
public class WorkflowTemplateController : BaseController
{
    private readonly IWorkflowTemplateService _workflowTemplateService;

    /// <inheritdoc />
    public WorkflowTemplateController(
        IWorkflowTemplateService workflowTemplateService
    )
    {
        _workflowTemplateService = workflowTemplateService;
    }

    /// <summary>
    ///     创建模板
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<WorkflowTemplateDto> CreateWorkflowTemplate(WorkflowTemplateDto workflow)
    {
        return await _workflowTemplateService.CreateWorkflowTemplate(workflow);
    }

    /// <summary>
    /// 获取模板列表
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagingModelView<List<WorkflowTemplateDto>>> GetWorkflowTemplatePage(string? name, int pageNo = 1,
        int pageSize = 20)
    {
        var data = await _workflowTemplateService.GetWorkflowTemplatePage(name, pageNo, pageSize);
        return new PagingModelView<List<WorkflowTemplateDto>>(SerialNumberHelper.GetList(data.Item1, pageNo, pageSize),
            data.Item2);
    }

    /// <summary>
    ///     删除模板
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task DeleteWorkflowTemplate(Guid id)
    {
        await _workflowTemplateService.DeleteWorkflowTemplate(id);
    }

    /// <summary>
    ///     编辑模板
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task UpdateWorkflowTemplate(WorkflowTemplateDto workflow)
    {
        await _workflowTemplateService.UpdateWorkflowTemplate(workflow);
    }

    /// <summary>
    ///     获取模板节点配置
    /// </summary>
    /// <param name="workflowId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<WorkflowNodeTemplateDto>> GetWorkflowNodeTemplates(Guid workflowId)
    {
        return await _workflowTemplateService.GetWorkflowNodeTemplates(workflowId);
    }

    /// <summary>
    ///     获取节点已存在角色
    /// </summary>
    /// <param name="workflowNodeId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<Guid>> GetWorkflowNodeRoleIds(Guid workflowNodeId)
    {
        return await _workflowTemplateService.GetWorkflowNodeRoleIds(workflowNodeId);
    }

    /// <summary>
    ///     创建节点角色
    /// </summary>
    /// <param name="workflowNodeId"></param>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task CreateWorkflowNodeRole(Guid workflowNodeId, [FromBody] List<Guid> roleIds)
    {
        await _workflowTemplateService.CreateWorkflowNodeRole(workflowNodeId, roleIds);
    }

    /// <summary>
    ///     编辑节点信息
    /// </summary>
    /// <param name="workflowNodeTemplate"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task UpdateWorkflowNodeTemplate(WorkflowNodeTemplateDto workflowNodeTemplate)
    {
        await _workflowTemplateService.UpdateWorkflowNodeTemplate(workflowNodeTemplate);
    }

    /// <summary>
    ///     创建节点信息
    /// </summary>
    /// <param name="templateDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<WorkflowNodeTemplateDto> CreateWorkflowNodeTemplate(WorkflowNodeTemplateDto templateDto)
    {
        if (templateDto.WorkflowTemplateId == Guid.Empty)
        {
            throw new BusinessException("模板id不能为空");
        }

        return await _workflowTemplateService.CreateWorkflowNodeTemplate(templateDto);
    }

    /// <summary>
    ///     删除模板节点
    /// </summary>
    /// <param name="workflowNodeId"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task DeleteWorkflowNodeTemplate(Guid workflowNodeId)
    {
        await _workflowTemplateService.DeleteWorkflowNodeTemplate(workflowNodeId);
    }

    /// <summary>
    ///     编辑模板节点审批顺序
    /// </summary>
    /// <param name="workflows"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<List<WorkflowNodeTemplateDto>> UpdateWorkflowNodeTemplateIndex(
        List<WorkflowNodeTemplateDto> workflows)
    {
        return await _workflowTemplateService.UpdateWorkflowNodeTemplateIndex(workflows);
    }

    /// <summary>
    ///     获取所有模板
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<WorkflowTemplateDto>> GetWorkflowTemplatesAll()
    {
        return await _workflowTemplateService.GetWorkflowTemplatesAll();
    }

    /// <summary>
    ///     判断当前人是否可以审批当前节点
    /// </summary>
    /// <param name="nodeTemplateId"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<bool> IsExamineAndApprove(Guid nodeTemplateId)
    {
        return await _workflowTemplateService.IsExamineAndApprove(nodeTemplateId);
    }
}
