using AutoMapper;
using Token.Infrastructure.Extension;
using Token.Management.Application.Contracts.AppServices.WorkFlow;
using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Application.Contracts.Module.WorkFlow;
using Token.Management.Domain;
using Token.Management.Domain.Shared;
using Token.Management.Domain.WorkFlow;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Application.Services.WorkFlow;

public class WorkflowInstanceService : ApplicationService, IWorkflowInstanceService, ISingletonDependency
{
    private readonly IMapper _mapper;
    private readonly IWorkflowInstanceRepository _workflowInstanceRepository;
    private readonly IWorkflowTemplateService _workflowTemplateService;
    public WorkflowInstanceService(
        IMapper mapper,
        IWorkflowTemplateService workflowTemplateService,
        IWorkflowInstanceRepository workflowInstanceRepository)
    {
        _mapper = mapper;
        _workflowTemplateService = workflowTemplateService;
        _workflowInstanceRepository = workflowInstanceRepository;
    }

    public async Task<WorkflowInstanceDto> CreateWorkflowInstance(CreateWorkflowInstanceDto dto, UserInfoDto userInfo)
    {
        if (dto.WorkFormId == Guid.Empty)
            throw new BusinessException("工作流关联表单不能为空");

        if (dto.WorkflowTemplateCode.IsNull())
            throw new BusinessException("工作流归属模板编码不能为空");

        var now=DateTime.Now;
        var workflow = new WorkflowInstanceDto
        {
            SponsorId = userInfo.Id,
            SponsorName = userInfo.Name,
            SponsoredDate = now,
            HasBeenRead = false,
            WorkflowStatus = WorkFlowStatusEnum.Approving
        };

        //获取下一节点id
        var nodeId=await _workflowTemplateService.GetObtainingTemplateNode(dto.WorkflowTemplateCode!, null,userInfo.Id);

        workflow.WorkflowApprovers.Add(new WorkflowApproversDto
        {
            UserInfoId = userInfo.Id,
            UserName = userInfo.Name,
            WorkFlowFormCode = WorkFlowFormCodeEnum.SystemMessage,
        });

        workflow.WorkflowNodeInstances.Add(new WorkflowNodeInstanceDto
        {
            AuditDate = now,
            AuditPersonId = userInfo.Id,
            AuditPersonName = userInfo.Name,
            NextNodeId = nodeId,
            NodeStatus= WorkFlowNodeStatusEnum.Pass,
            Name=workflow.Name,
            NextTemplateNodeId = nodeId,
            PrevTemplateNodeId=null,
            PrevNodeId=null,
            Remark=workflow.Remark,
            Code=1//创建工作流实例应该从1开始
        });

        var workflowData = _mapper.Map<WorkflowInstance>(workflow);

        workflowData =await _workflowInstanceRepository.InsertAsync(workflowData);

        return _mapper.Map<WorkflowInstanceDto>(workflowData);
    }
}
