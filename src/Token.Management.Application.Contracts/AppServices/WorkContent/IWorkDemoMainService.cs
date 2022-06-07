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
    Task CreateWorkDemoMain(WorkDemoMainDto dto);
}
