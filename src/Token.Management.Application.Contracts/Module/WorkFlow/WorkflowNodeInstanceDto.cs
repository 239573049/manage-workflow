﻿using Token.Management.Domain.Shared;

namespace Token.Management.Application.Contracts.Module.WorkFlow;

public class WorkflowNodeInstanceDto
{
    public Guid Id { get; set; }

    /// <summary>
    ///     关联流程
    /// </summary>
    public Guid WorkflowInstanceId { get; set; }

    /// <summary>
    ///     节点名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     节点审批顺序
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    ///     模板步骤【模板】
    /// </summary>
    public Guid TemplateNodeId { get; set; }

    /// <summary>
    ///     模板前一步骤【模板设定】
    /// </summary>
    public Guid? PrevTemplateNodeId { get; set; }

    /// <summary>
    ///     模板下一步骤【模板设定】
    /// </summary>
    public Guid? NextTemplateNodeId { get; set; }

    /// <summary>
    ///     上一节点【真实执行】
    /// </summary>
    public Guid? PrevNodeId { get; set; }

    /// <summary>
    ///     下一节点【真实执行】
    /// </summary>
    public Guid? NextNodeId { get; set; }

    /// <summary>
    ///     描述
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    ///     当前节点实际审批人
    /// </summary>
    public Guid? AuditPersonId { get; set; }

    /// <summary>
    ///     当前节点实际审批人姓名
    /// </summary>
    public string? AuditPersonName { get; set; }

    /// <summary>
    ///     审批时间
    /// </summary>
    public DateTime? AuditDate { get; set; }

    /// <summary>
    ///     节点审批状态
    /// </summary>
    public WorkFlowNodeStatusEnum NodeStatus { get; set; }

    public WorkflowInstanceDto? WorkflowInstance { get; set; }
}
