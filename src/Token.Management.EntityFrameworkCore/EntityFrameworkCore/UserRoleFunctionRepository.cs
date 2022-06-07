using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Token.Management.Domain.Management.AccessFunction;
using Token.Management.Domain.Users;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore;

public class UserRoleFunctionRepository:EfCoreRepository<TokenDbContext,UserRoleFunction,Guid>,IUserRoleFunctionRepository
{
    public UserRoleFunctionRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<(List<UserRoleFunction>, int)> GetPageListAsync<TKey>(Expression<Func<UserRoleFunction, bool>> expression,
        Expression<Func<UserRoleFunction,TKey>> sort, int skipCount,int maxResultCount)
    {
        var dbContext = await GetDbContextAsync();

        var query =
            dbContext.UserRoleFunction.Where(expression)
                .OrderBy(sort);

        var count =await query.CountAsync();

        var result =await query.PageBy(skipCount, maxResultCount).ToListAsync();

        return (result, count);
    }

    public async Task<(List<UserInfo>, int)> GetPageUserListAsync<TKey>(Expression<Func<UserRoleFunction, bool>> expression, Expression<Func<UserRoleFunction, TKey>> sort, int skipCount, int maxResultCount)
    {
        var dbContext = await GetDbContextAsync();

        var query =
            dbContext.UserRoleFunction.Where(expression)
                .OrderBy(sort)
                .Select(x=>x.UserInfo);

        var count =await query.CountAsync();

        var result =await query.PageBy(skipCount, maxResultCount).ToListAsync();

        return (result, count);
    }

    public async Task<List<TEntity>> GetListAsync<TEntity,TProperty>(Expression<Func<UserRoleFunction,bool>> expression,
        Expression<Func<UserRoleFunction,TEntity>> select,Expression<Func<UserRoleFunction,TProperty>>? property=null)
    {
        var dbContext =await GetDbContextAsync();

        var query=dbContext.UserRoleFunction.Where(expression);

        if (property != null)
        {
            query = query.Include(property);
        }

        return await query
            .Select(select).ToListAsync();
    }

    public async Task<List<UserInfo>> GetUserInfoAsync(Expression<Func<UserRoleFunction, bool>> expression)
    {
        var dbContext = await GetDbContextAsync();

        var query = dbContext.UserRoleFunction.Where(expression)
            .Select(x=>x.UserInfo);

        return await query.ToListAsync();
    }
}
