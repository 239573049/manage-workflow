using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Token.Management.Domain;
using Token.Management.Domain.WorkFlow;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore.WorkFlow;

public class WorkflowNodeTemplateRepository:EfCoreRepository<TokenDbContext,WorkflowNodeTemplate,Guid>,IWorkflowNodeTemplateRepository
{
    public WorkflowNodeTemplateRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Guid> GetTheNextNodeIdAsync(Guid id)
    {
        var dbContext = await GetDbContextAsync();

        var node = await
            dbContext.WorkflowNodeTemplate.Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        if (node == null)
            throw new BusinessException("节点不存在");

        var nextNode = await
            dbContext.WorkflowNodeTemplate
            .Where(x => x.WorkflowTemplateId == node.WorkflowTemplateId && x.Code == (node.Code + 1))
            .Select(x=>x.Id)
            .FirstOrDefaultAsync();

        return nextNode;
    }

    public async Task<int> GetWorkflowNodeTemplateMaxIndex(Guid workflowTemplateId)
    {
        var dbContext = await GetDbContextAsync();

        return (await dbContext.WorkflowNodeTemplate.Where(x => x.WorkflowTemplateId == workflowTemplateId)
            .CountAsync())+ 1;
    }

    public async Task<List<Guid>> GetWorkflowNodeRoleIdsAsync(Expression<Func<WorkflowNodeTemplate, bool>> expression)
    {
        var dbContext = await GetDbContextAsync();

        var query=  dbContext.WorkflowNodeTemplate
            .Where(expression)
            .SelectMany(x => x.WorkflowApprovalRole)
            .Select(x => x.RoleId);

        return await query.ToListAsync();
     }

    public async Task<WorkflowNodeTemplate> GetAsync(Expression<Func<WorkflowNodeTemplate,bool>> expression)
    {
        var dbContext = await GetDbContextAsync();

        var qeury =
            dbContext.WorkflowNodeTemplate
                .Where(expression)
                .Include(x => x.WorkflowApprovalRole)
                .FirstOrDefaultAsync();

        return await qeury;
    }

    public async Task<List<WorkflowNodeTemplate>> GetListAsync(Expression<Func<WorkflowNodeTemplate, bool>> expression)
    {
        var dbContext = await GetDbContextAsync();

        var query =
            dbContext.WorkflowNodeTemplate
                .Where(expression)
                .Include(x => x.WorkflowApprovalRole)
                .ToListAsync();

        return await query;
    }

    public async Task<List<WorkflowApprovalRole>> GetWorkflowNodeRoleListAsync(Expression<Func<WorkflowNodeTemplate, bool>> expression)
    {
        var dbContext = await GetDbContextAsync();

        return await dbContext.WorkflowNodeTemplate
            .Where(expression)
            .SelectMany(x => x.WorkflowApprovalRole)
            .ToListAsync();
    }
}
