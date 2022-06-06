using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Token.Management.Domain.WorkFlow;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore.WorkFlow;

public class WorkflowTemplateRepository:EfCoreRepository<TokenDbContext,WorkflowTemplate,Guid>,IWorkflowTemplateRepository
{
    public WorkflowTemplateRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    ///<inheritdoc />
    public async Task<WorkflowTemplate> GetAsync(Expression<Func<WorkflowTemplate, bool>> expression)
    {
        var dbContext = await GetDbContextAsync();

        var query =
            dbContext.WorkflowTemplate
                .Where(expression)
                .Include(x => x.WorkflowNodeTemplate)
                .FirstOrDefaultAsync();

        return await query;
    }

    public async Task<List<WorkflowNodeTemplate>> GetListAsync(Expression<Func<WorkflowTemplate, bool>> expression)
    {
        var dbContext = await GetDbContextAsync();

        var query =
            dbContext.WorkflowTemplate
                .AsSplitQuery()
                .Where(expression)
                .Include(x=>x.WorkflowNodeTemplate)
                .SelectMany(x => x.WorkflowNodeTemplate)
                .Include(a=>a.WorkflowApprovalRole)
                .OrderBy(a=>a.Code);

        return await query.ToListAsync();
    }

    public async Task<(List<WorkflowTemplate>, int)> GetPageListAsync<TKey>(Expression<Func<WorkflowTemplate, bool>> expression, Expression<Func<WorkflowTemplate, TKey>> sort, int skipCount, int maxResultCount)
    {
        var dbContext = await GetDbContextAsync();

        var query =
            dbContext.WorkflowTemplate
                .Where(expression)
                .OrderBy(sort);

        var count =await query.CountAsync();

        var result = await query.PageBy(skipCount, maxResultCount)
            .ToListAsync();

        return (result, count);
    }
}
