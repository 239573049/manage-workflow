using System.Linq.Expressions;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Domain.WorkFlow;

/// <summary>
///
/// </summary>
public interface IWorkflowTemplateRepository:IRepository<WorkflowTemplate,Guid>
{
    /// <summary>
    /// 获取工作流模板
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<WorkflowTemplate> GetAsync(Expression<Func<WorkflowTemplate,bool>> expression);

    /// <summary>
    /// 获取工作流模板列表
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<List<WorkflowNodeTemplate>> GetListAsync(Expression<Func<WorkflowTemplate,bool>> expression);

    /// <summary>
    ///
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="select"></param>
    /// <param name="skipCount"></param>
    /// <param name="maxResultCount"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    Task<(List<WorkflowTemplate>,int)> GetPageListAsync<TKey>(Expression<Func<WorkflowTemplate,bool>> expression,Expression<Func<WorkflowTemplate,TKey>> select,int skipCount,int maxResultCount);
}
