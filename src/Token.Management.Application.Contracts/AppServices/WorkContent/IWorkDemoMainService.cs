namespace Token.Management.Application.Contracts.AppServices.WorkContent;

/// <summary>
/// WorkDemo实例
/// </summary>
public interface IWorkDemoMainService
{
    /// <summary>
    /// 创建一个Demo
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task CreateWorkDemoMainAsync(WorkDemoMainDto dto);

    /// <summary>
    /// 获取Demo列表
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <param name="keyword"></param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    Task<(List<WorkDemoMainDto>, int)> GetWorkDemoListAsync(DateTime? startTime,DateTime? endTime,string keyword,int pageNo,int pageSize);
}
