using Token.Management.Application.Contracts.AppServices.WorkContent;
using Token.Management.Domain.WorkContent;
using Volo.Abp.Application.Services;

namespace Token.Management.Application.Services.WorkContent;

public class WorkDemoMainService:ApplicationService,IWorkDemoMainService
{
    private readonly IWorkDemoMainRepository _workDemoMainRepository;

    public WorkDemoMainService(IWorkDemoMainRepository workDemoMainRepository)
    {
        _workDemoMainRepository = workDemoMainRepository;
    }

    public Task CreateWorkDemoMain(WorkDemoMainDto dto)
    {
        throw new NotImplementedException();
    }
}
