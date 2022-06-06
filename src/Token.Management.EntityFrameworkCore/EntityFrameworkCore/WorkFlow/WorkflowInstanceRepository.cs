using Token.Management.Domain.WorkFlow;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore.WorkFlow;

public class WorkflowInstanceRepository:EfCoreRepository<TokenDbContext,WorkflowInstance,Guid>,IWorkflowInstanceRepository
{
    public WorkflowInstanceRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
