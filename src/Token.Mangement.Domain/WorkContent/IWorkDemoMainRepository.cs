using Volo.Abp.Domain.Repositories;

namespace Token.Management.Domain.WorkContent;

/// <summary>
/// 工作Demo
/// </summary>
public interface IWorkDemoMainRepository:IRepository<WorkDemoMain,Guid>
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="keyword"></param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<(List<WorkDemoMain>, int)> GetWorkDemoListAsync(DateTime? startTime, DateTime? endTime, string keyword,
        int pageNo, int pageSize);
}
