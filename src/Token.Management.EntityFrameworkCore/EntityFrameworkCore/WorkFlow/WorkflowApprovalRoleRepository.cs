using Token.Management.Domain.WorkFlow;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore.WorkFlow;

public class WorkflowApprovalRoleRepository:EfCoreRepository<TokenDbContext,WorkflowApprovalRole,Guid>,IWorkflowApprovalRoleRepository
{
    public WorkflowApprovalRoleRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

}
