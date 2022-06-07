using Token.Management.Domain.WorkContent;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore.WorkContent;

public class WorkDemoMainRepository:EfCoreRepository<TokenDbContext,WorkDemoMain,Guid>,IWorkDemoMainRepository
{
    public WorkDemoMainRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    
}
