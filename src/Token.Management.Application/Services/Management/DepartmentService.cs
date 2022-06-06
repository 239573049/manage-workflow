using Management.Application.Services.Management;
using Token.Management.Domain.Management;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Application.Services.Management;

public class DepartmentService : ApplicationService, IDepartmentService, ISingletonDependency
{
    private readonly IRepository<Department> _departmentRepository;
    public DepartmentService(IRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<List<Department>> GetUserDepartmentsAsync(Guid userId)=>
        await _departmentRepository.GetListAsync(a => a.UserDepartmentFunction.Any(a => a.UserInfoId == userId));
}
