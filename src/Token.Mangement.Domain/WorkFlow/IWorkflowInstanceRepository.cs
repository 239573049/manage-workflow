using Volo.Abp.Domain.Repositories;

namespace Token.Management.Domain.WorkFlow;

/// <summary>
///
/// </summary>
public  interface IWorkflowInstanceRepository:IRepository<WorkflowInstance,Guid>
{

}
