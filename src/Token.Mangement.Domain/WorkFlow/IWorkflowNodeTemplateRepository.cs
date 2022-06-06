using System.Linq.Expressions;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Domain.WorkFlow;

/// <summary>
///
/// </summary>
public interface IWorkflowNodeTemplateRepository:IRepository<WorkflowNodeTemplate,Guid>
{
    /// <summary>
    /// 获取下一节点id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Guid> GetTheNextNodeIdAsync(Guid id);
    /// <summary>
    /// 获取模板的节点最大节点顺序
    /// </summary>
    /// <param name="workflowTemplateId"></param>
    /// <returns></returns>
    Task<int> GetWorkflowNodeTemplateMaxIndex(Guid workflowTemplateId);

    /// <summary>
    /// 获取节点角色Id
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<List<Guid>> GetWorkflowNodeRoleIdsAsync(Expression<Func<WorkflowNodeTemplate, bool>> expression);

    /// <summary>
    /// 获取节点模板
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<WorkflowNodeTemplate> GetAsync(Expression<Func<WorkflowNodeTemplate,bool>> expression);

    /// <summary>
    /// 获取节点模板集合
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<List<WorkflowNodeTemplate>> GetListAsync(Expression<Func<WorkflowNodeTemplate, bool>> expression);

    /// <summary>
    /// 获取节点角色
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<List<WorkflowApprovalRole>> GetWorkflowNodeRoleListAsync(Expression<Func<WorkflowNodeTemplate,bool>> expression);
}
