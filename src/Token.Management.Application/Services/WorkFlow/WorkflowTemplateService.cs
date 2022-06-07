using AutoMapper;
using Management.Application.Services.Management;
using Token.HttpApi;
using Token.Infrastructure.Extension;
using Token.Management.Application.Contracts.AppServices.WorkFlow;
using Token.Management.Application.Contracts.Module;
using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Application.Contracts.Module.WorkFlow;
using Token.Management.Domain;
using Token.Management.Domain.Users;
using Token.Management.Domain.WorkFlow;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Application.Services.WorkFlow;

public class WorkflowTemplateService : ApplicationService, IWorkflowTemplateService
{
    private readonly IRoleService _iRoleService;
    private readonly IPrincipalAccessor _principalAccessor;
    private readonly IWorkflowTemplateRepository _workflowTemplateRepository;
    private readonly IWorkflowApprovalRoleRepository _workflowApprovalRoleRepository;
    private readonly IWorkflowNodeTemplateRepository _workflowNodeTemplateRepository;
    public WorkflowTemplateService(
        IRoleService iRoleService,
        IPrincipalAccessor principalAccessor,
        IWorkflowApprovalRoleRepository workflowApprovalRoleRepository,
        IWorkflowNodeTemplateRepository workflowNodeTemplateRepository, IWorkflowTemplateRepository workflowTemplateRepository)
    {
        _iRoleService = iRoleService;
        _principalAccessor = principalAccessor;
        _workflowApprovalRoleRepository = workflowApprovalRoleRepository;
        _workflowNodeTemplateRepository = workflowNodeTemplateRepository;
        _workflowTemplateRepository = workflowTemplateRepository;
    }

    public async Task CreateWorkflowNodeRole(Guid workflowNodeId, List<Guid> roleIds)
    {
        var data = await _workflowNodeTemplateRepository.GetWorkflowNodeRoleIdsAsync(a => a.Id == workflowNodeId);

        await _workflowApprovalRoleRepository.DeleteManyAsync(data);

        var roleData = roleIds
            .Select(a => new WorkflowApprovalRole { WorkflowNodeTemplateId = workflowNodeId, RoleId = a }).ToList();

        await _workflowApprovalRoleRepository.InsertManyAsync(roleData);

    }

    public async Task<WorkflowNodeTemplateDto> CreateWorkflowNodeTemplate(WorkflowNodeTemplateDto templateDto)
    {
        var data = ObjectMapper.Map<WorkflowNodeTemplateDto,WorkflowNodeTemplate>(templateDto);
        var code = await _workflowNodeTemplateRepository.GetWorkflowNodeTemplateMaxIndex(templateDto.WorkflowTemplateId);
        data.Code = code;
        data = await _workflowNodeTemplateRepository.InsertAsync(data);

        return ObjectMapper.Map<WorkflowNodeTemplate,WorkflowNodeTemplateDto>(data);
    }

    public async Task<WorkflowTemplateDto> CreateWorkflowTemplate(WorkflowTemplateDto workflow)
    {
        if (workflow.Name.IsNull())
            throw new BusinessException("模板名称不能为空");

        if (workflow.Code.IsNull())
            throw new BusinessException("模板编号不能为空");

        if (await _workflowTemplateRepository.AnyAsync(a => a.Name == workflow.Name || a.Code == workflow.Code))
            throw new BusinessException("模板编号或者模板名称重复");

        var data = ObjectMapper.Map<WorkflowTemplateDto,WorkflowTemplate>(workflow);

        data.WorkflowInstance = new List<WorkflowInstance>();

        data = await _workflowTemplateRepository.InsertAsync(data);


        return ObjectMapper.Map<WorkflowTemplate,WorkflowTemplateDto>(data);
    }

    public async Task DeleteWorkflowNodeTemplate(Guid workflowNodeId)
    {
        var data = await _workflowNodeTemplateRepository.FirstOrDefaultAsync(a => a.Id == workflowNodeId);

        if (data == null)
            throw new BusinessException("数据不存在");

        var workflowNode = await _workflowNodeTemplateRepository
            .GetListAsync(a => a.WorkflowTemplateId == data.WorkflowTemplateId && a.Id != workflowNodeId);

        await _workflowNodeTemplateRepository.DeleteAsync(workflowNodeId);

        UpdateWorkflowNodeTemplateHandleIndex(workflowNode);
    }

    public async Task DeleteWorkflowTemplate(Guid id)
    {
        var data = await _workflowTemplateRepository.GetAsync(a => a.Id == id);

        if (data == null)
            throw new BusinessException("模板数据不存在或者已经被删除");

        await _workflowTemplateRepository.DeleteAsync(x => x.Id == data.Id);

        await _workflowNodeTemplateRepository.DeleteManyAsync(data.WorkflowNodeTemplate.Select(a => a.Id).ToList());

    }

    public async Task<List<Guid>> GetWorkflowNodeRoleIds(Guid workflowNodeId)
    {
        return await _workflowNodeTemplateRepository
            .GetWorkflowNodeRoleIdsAsync(a => a.Id == workflowNodeId);
    }

    public async Task<List<WorkflowNodeTemplateDto>> GetWorkflowNodeTemplates(Guid workflowId)
    {
        var data = (await _workflowNodeTemplateRepository
            .GetListAsync(a => a.WorkflowTemplateId == workflowId)).OrderBy(x => x.Code)
            .ToList();

        return ObjectMapper.Map<List<WorkflowNodeTemplate>,List<WorkflowNodeTemplateDto>>(data);
    }

    public async Task<(List<WorkflowTemplateDto>, int)> GetWorkflowTemplatePage(string? name, PageInput input)
    {
        var data =
            await _workflowTemplateRepository
                .GetPageListAsync(name, input.SkipCount, input.MaxResultCount);

        return (ObjectMapper.Map<List<WorkflowTemplate>,List<WorkflowTemplateDto>>(data.Item1), data.Item2);
    }

    public async Task UpdateWorkflowNodeTemplate(WorkflowNodeTemplateDto workflowNodeTemplate)
    {
        var data = await _workflowNodeTemplateRepository.FirstOrDefaultAsync(a => a.Id == workflowNodeTemplate.Id);
        if (data == null)
            throw new BusinessException("数据不存在或者已经被删除");

        data.Remark = workflowNodeTemplate.Remark;

        //只修改备注
        await _workflowNodeTemplateRepository.UpdateAsync(data);

    }

    public async Task<List<WorkflowNodeTemplateDto>> UpdateWorkflowNodeTemplateIndex(List<WorkflowNodeTemplateDto> workflows)
    {
        var data = ObjectMapper.Map<List<WorkflowNodeTemplateDto>,List<WorkflowNodeTemplate>>(workflows);

        UpdateWorkflowNodeTemplateHandleIndex(data);

        return await Task.FromResult(ObjectMapper.Map<List<WorkflowNodeTemplate>,List<WorkflowNodeTemplateDto>>(data));
    }

    public void UpdateWorkflowNodeTemplateHandleIndex(List<WorkflowNodeTemplate> workflows)
    {
        int i = 1;

        workflows.ForEach(a =>
        {
            a.Code = i++;
        });
        _workflowNodeTemplateRepository.UpdateManyAsync(workflows);

    }

    public async Task UpdateWorkflowTemplate(WorkflowTemplateDto workflow)
    {
        var data = await _workflowTemplateRepository.FirstOrDefaultAsync(a => a.Id == workflow.Id);

        if (data == null)
            throw new BusinessException("模板数据不存在或者已经被删除");

        if (await _workflowTemplateRepository.AnyAsync(a => workflow.Id != a.Id && (a.Name == workflow.Name || a.Code == workflow.Code)))
            throw new BusinessException("模板编号或者模板名称重复");

        ObjectMapper.Map(workflow, data);

        await _workflowTemplateRepository.UpdateAsync(data);


    }

    public async Task<List<WorkflowTemplateDto>> GetWorkflowTemplatesAll()
    {
        var data = await _workflowTemplateRepository.GetListAsync();

        return ObjectMapper.Map<List<WorkflowTemplate>,List<WorkflowTemplateDto>>(data);
    }

    public async Task<Guid?> GetsTheNextNode(Guid id)
    {
        var result = await _workflowNodeTemplateRepository.GetTheNextNodeIdAsync(id);

        return result;
    }

    public async Task<List<WorkflowNodeTemplateDto>> GetWorkflowNodeTemplateList(Guid workTemplateId)
    {
        var data = await _workflowNodeTemplateRepository.GetListAsync(a => a.Id == workTemplateId);

        return ObjectMapper.Map<List<WorkflowNodeTemplate>,List<WorkflowNodeTemplateDto>>(data);
    }

    public async Task<List<WorkflowNodeRoleUserInfoDto>> GetWorkflowNodeRoleUserInfoDto(Guid workTemplateId)
    {
        var data = await _workflowNodeTemplateRepository.GetListAsync(a => a.WorkflowTemplateId == workTemplateId);

        var roles = data.SelectMany(a => a.WorkflowApprovalRole).Select(a => a.RoleId).ToList();

        var userInfo = await _iRoleService.GetRoleUserAllAsync(roles);
        var workflowNodeRoleUserInfos = new List<WorkflowNodeRoleUserInfoDto>();
        foreach (var d in data)
        {
            var workflowNodeRoleUserInfo = new WorkflowNodeRoleUserInfoDto
            {
                Id = d.Id,
                Code = d.Code,
                Remark = d.Remark,
                UserInfo = ObjectMapper
                    .Map<IEnumerable<UserInfo>,List<UserInfoDto>>(userInfo.FindAll(a => d.WorkflowApprovalRole.Select(a => a.RoleId).Contains(a.RoleId)).Select(x=>x.UserInfo).Distinct())
            };
            workflowNodeRoleUserInfos.Add(workflowNodeRoleUserInfo);
        }
        return workflowNodeRoleUserInfos;
    }

    public async Task<bool> IsExamineAndApprove(Guid nodeTemplateId)
    {
        var userRoleIds = await _iRoleService.GetUserInfoRoleIds(_principalAccessor.UserId());

        var node = await _workflowNodeTemplateRepository.GetWorkflowNodeRoleIdsAsync(a => a.Id == nodeTemplateId);

        return node.Any(a => userRoleIds.Contains(a));
    }

    public async Task<Guid?> GetObtainingTemplateNode(string workflowTemplateCode, Guid? nodeId, Guid userId)
    {
        var data = await _workflowTemplateRepository.GetListAsync(a => a.Code == workflowTemplateCode);

        if (!data.Any())
            throw new BusinessException("当前模板未配置节点或者未找到编码");

        var role = await _iRoleService.GetUserInfoRoleIds(userId);
        var workRole = data.SelectMany(a => a.WorkflowApprovalRole).Select(a => a.RoleId);
        if (!workRole.Any(a => role.Contains(a)))
            throw new BusinessException("操作失败，您无权操作");
        if (nodeId == null)
        {
            return data.FirstOrDefault()?.Id;
        }
        else
        {
            var index = data.FirstOrDefault(a => a.Id == nodeId);
            if (index == null)
                throw new BusinessException("节点id不存在");
            var nodeTemplate = data.Where(a => a.Code > index.Code).OrderBy(a => a.Code).FirstOrDefault();
            return nodeTemplate?.Id ?? null;
        }
    }

    public async Task DeleteTemplate(Guid templateId)
    {
        await _workflowTemplateRepository.DeleteAsync(templateId);
    }
}
