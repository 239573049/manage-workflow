using Token.Management.Domain.Management;

namespace Management.Application.Services.Management;

public interface IDepartmentService
{
    /// <summary>
    ///     获取用户所在部门
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<Department>> GetUserDepartmentsAsync(Guid userId);
}
