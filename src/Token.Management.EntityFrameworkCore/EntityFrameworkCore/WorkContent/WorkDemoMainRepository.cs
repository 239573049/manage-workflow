using Microsoft.EntityFrameworkCore;
using Token.Management.Domain.WorkContent;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore.WorkContent;

public class WorkDemoMainRepository:EfCoreRepository<TokenDbContext,WorkDemoMain,Guid>,IWorkDemoMainRepository
{
    public WorkDemoMainRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<(List<WorkDemoMain>, int)> GetWorkDemoListAsync(DateTime? startTime, DateTime? endTime, string keyword, int pageNo, int pageSize)
    {
        var dbContext = await GetDbContextAsync();

        var query =
            dbContext.WorkDemoMain
                .WhereIf(!keyword.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(keyword) || x.Content.Contains(keyword) || x.Remark.Contains(keyword))
                .WhereIf(startTime.HasValue, x => x.CreationTime >= startTime)
                .WhereIf(endTime.HasValue, x => x.CreationTime <= endTime);

        var count = await query.CountAsync();

        var result = await query.PageBy(pageNo, pageSize).ToListAsync();

        return (result, count);
    }
}
