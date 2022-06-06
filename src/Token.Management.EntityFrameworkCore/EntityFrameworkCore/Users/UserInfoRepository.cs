using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Token.Management.Domain.Users;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Token.Management.EntityFrameworkCore.EntityFrameworkCore.Users;

public class UserInfoRepository:EfCoreRepository<TokenDbContext,UserInfo,Guid>,IUserInfoRepository
{
    public UserInfoRepository(IDbContextProvider<TokenDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<(List<UserInfo>, int)> GetListAsync<TKey>(Expression<Func<UserInfo, bool>> expression, Expression<Func<UserInfo, TKey>> sort, int skipCount, int maxResultCount)
    {
        var dbContext = await GetDbContextAsync();

        var query =
            dbContext.UserInfo.Where(expression)
                .OrderBy(sort);

        var count=await query.CountAsync();

        var result = await query.PageBy(skipCount, maxResultCount).ToListAsync();

        return (result, count);
    }

    public async Task<UserInfo?> GetAsync(Expression<Func<UserInfo, bool>> expression)
    {
        var dbContext = await GetDbContextAsync();

        var query =await
            dbContext.UserInfo
                .AsNoTracking()
                .AsSplitQuery()
                .Where(expression)
                .Include(x => x.MenuRoleFunction)
                .ThenInclude(x => x.Role)
                .Include(x => x.UserRoleFunction)
                .ThenInclude(x => x.Role)
                .Include(x=>x.UserDepartmentFunction)
                .ThenInclude(x=>x.Department)
                .FirstOrDefaultAsync();

        return query;
    }
}
