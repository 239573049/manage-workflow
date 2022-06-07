using Token.Management.Domain.WorkContent;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore.WorkContent;

public class WorkContentDemoRepository:EfCoreRepository<TokenDbContext,WorkContentDemo,Guid>,IWorkContentDemoRepository
{
    public WorkContentDemoRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

}
