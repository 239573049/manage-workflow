using Token.Management.Application.Contracts.AppServices.WorkContent;
using Token.Management.Domain;
using Token.Management.Domain.Shared;
using Token.Management.Domain.WorkContent;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Application.Services.WorkContent;

public class WorkDemoMainService:ApplicationService,IWorkDemoMainService
{
    private readonly IWorkDemoMainRepository _workDemoMainRepository;

    public WorkDemoMainService(IWorkDemoMainRepository workDemoMainRepository)
    {
        _workDemoMainRepository = workDemoMainRepository;
    }

    public async Task CreateWorkDemoMainAsync(WorkDemoMainDto dto)
    {
        if (await _workDemoMainRepository.AnyAsync(x => x.Name == dto.Name))
        {
            throw new BusinessException("存在重复名称");
        }

        var data = ObjectMapper.Map<WorkDemoMainDto,WorkDemoMain>(dto);
        data.WorkFlowNodeStatus = WorkFlowNodeStatusEnum.UnDeal;
        data =await _workDemoMainRepository.InsertAsync(data);
    }

    public async Task<(List<WorkDemoMainDto>, int)> GetWorkDemoListAsync(DateTime? startTime, DateTime? endTime, string keyword, int pageNo, int pageSize)
    {
        var result = await _workDemoMainRepository.GetWorkDemoListAsync(startTime, endTime, keyword, pageNo, pageSize);

        return (ObjectMapper.Map<List<WorkDemoMain>,List<WorkDemoMainDto>>(result.Item1),result.Item2);
    }
}
