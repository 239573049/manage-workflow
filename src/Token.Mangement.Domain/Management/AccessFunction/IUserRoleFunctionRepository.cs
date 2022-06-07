using System.Linq.Expressions;
using Token.Management.Domain.Users;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Domain.Management.AccessFunction;

/// <summary>
/// UserRole
/// </summary>
public interface IUserRoleFunctionRepository:IRepository<UserRoleFunction,Guid>
{
    /// <summary>
    /// 分页获取排序
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="sort"></param>
    /// <param name="skipCount"></param>
    /// <param name="maxResultCount"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    Task<(List<UserRoleFunction>, int)> GetPageListAsync<TKey>(Expression<Func<UserRoleFunction,bool>> expression,
        Expression<Func<UserRoleFunction,TKey>> sort,int skipCount,int maxResultCount);

    /// <summary>
    /// 分页获取排序
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="sort"></param>
    /// <param name="skipCount"></param>
    /// <param name="maxResultCount"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    Task<(List<UserInfo>, int)> GetPageUserListAsync<TKey>(Expression<Func<UserRoleFunction,bool>> expression,
        Expression<Func<UserRoleFunction,TKey>> sort,int skipCount,int maxResultCount);

    /// <summary>
    ///
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="select"></param>
    /// <param name="property"></param>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <returns></returns>
    Task<List<TEntity>> GetListAsync<TEntity,TProperty>(Expression<Func<UserRoleFunction,bool>> expression,
        Expression<Func<UserRoleFunction,TEntity>> select,Expression<Func<UserRoleFunction,TProperty>>? property=null);

}
