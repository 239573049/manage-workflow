using System.Linq.Expressions;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Domain.Users;

/// <summary>
/// UserInfo仓储
/// </summary>
public interface IUserInfoRepository:IRepository<UserInfo,Guid>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="sort"></param>
    /// <param name="skipCount"></param>
    /// <param name="maxResultCount"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    Task<(List<UserInfo>, int)> GetListAsync<TKey>(Expression<Func<UserInfo,bool>> expression,Expression<Func<UserInfo,TKey>> sort,int skipCount,int maxResultCount);

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Task<UserInfo?> GetAsync(Expression<Func<UserInfo, bool>> expression);
}
