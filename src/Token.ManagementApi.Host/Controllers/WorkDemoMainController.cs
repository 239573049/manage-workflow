using Microsoft.AspNetCore.Mvc;
using Token.Management.Application.Contracts.AppServices.WorkContent;
using Token.Management.Application.Contracts.Module;
using Token.ManagementApi.Host.Module;

namespace Token.ManagementApi.Host.Controllers;

/// <summary>
/// Demo
/// Demo
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class WorkDemoMainController:ControllerBase
{
    private readonly IWorkDemoMainService _workDemoMainService;

    /// <inheritdoc />
    public WorkDemoMainController(IWorkDemoMainService workDemoMainService)
    {
        _workDemoMainService = workDemoMainService;
    }

    /// <summary>
    /// 创建Demo
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost]
    public async Task CreateWorkDemoMainAsync(WorkDemoMainDto dto)
    {
        await _workDemoMainService.CreateWorkDemoMainAsync(dto);
    }

    /// <summary>
    /// 获取Demo列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagingModelView<List<WorkDemoMainDto>>> GetWorkDemoListAsync(PageInput input)
    {
        var result = await _workDemoMainService.GetWorkDemoListAsync(input.StartTime, input.EndTime, input.Keyword,
            input.SkipCount, input.MaxResultCount);

        return new PagingModelView<List<WorkDemoMainDto>>(result.Item1,result.Item2);
    }
}
