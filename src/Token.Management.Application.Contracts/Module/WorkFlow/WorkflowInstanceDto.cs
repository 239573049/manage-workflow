using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Domain.Shared;

namespace Token.Management.Application.Contracts.Module.WorkFlow;

public class WorkflowInstanceDto
{
    public Guid Id { get; set; }

    /// <summary>
    ///     流程发起人
    /// </summary>
    public Guid SponsorId { get; set; }

    /// <summary>
    ///     流程发起人姓名
    /// </summary>
    public string? SponsorName { get; set; }

    /// <summary>
    ///     流程实例名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     流程编码
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    ///     描述
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    ///     归属流程模板
    /// </summary>
    public Guid WorkflowTemplateId { get; set; }

    /// <summary>
    ///     关联表单
    /// </summary>
    public Guid WorkFormId { get; set; }

    /// <summary>
    ///     流程状态
    /// </summary>
    public WorkFlowStatusEnum WorkflowStatus { get; set; }

    /// <summary>
    ///     流程发起时间
    /// </summary>
    public DateTime? SponsoredDate { get; set; }

    /// <summary>
    ///     表单标识
    /// </summary>
    public WorkFlowFormCodeEnum WorkFlowFormCode { get; set; }

    /// <summary>
    ///     归档时间
    /// </summary>
    public DateTime? ArchiveDate { get; set; }

    /// <summary>
    ///     流程已经被读【流程第一次被审批人员打开后，该字段置为true】
    /// </summary>
    public bool HasBeenRead { get; set; } = false;

    /// <summary>
    ///     审批角色编码
    /// </summary>
    public string? CurrentRoleCode { get; set; }

    /// <summary>
    ///     发起人信息
    /// </summary>
    public UserInfoDto? Sponsor { get; set; }

    public WorkflowTemplateDto? WorkflowTemplate { get; set; }

    /// <summary>
    ///     已审核人员信息
    /// </summary>
    public List<WorkflowApproversDto> WorkflowApprovers { get; set; } = new();

    /// <summary>
    ///     当前实际的流程节点
    /// </summary>
    public List<WorkflowNodeInstanceDto> WorkflowNodeInstances { get; set; } = new();
}
