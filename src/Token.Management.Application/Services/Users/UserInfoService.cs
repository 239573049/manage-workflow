using Token.HttpApi;
using Token.Infrastructure.Extension;
using Token.Management.Application.Contracts.AppServices.Users;
using Token.Management.Application.Contracts.Module.Management;
using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Domain;
using Token.Management.Domain.Management;
using Token.Management.Domain.Shared;
using Token.Management.Domain.Users;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Application.Services.Users;

public class UserInfoService : ApplicationService, IUserInfoService
{
    private readonly DESHelper _desHelper;
    private readonly IPrincipalAccessor _principalAccessor;
    private readonly IUserInfoRepository _userInfoRepository;
    public UserInfoService(
        IPrincipalAccessor principalAccessor,
        IUserInfoRepository userInfoRepository, DESHelper desHelper)
    {
        _principalAccessor = principalAccessor;
        _userInfoRepository = userInfoRepository;
        _desHelper = desHelper;
    }

    public async Task<UserInfoDto> CreateUserInfo(UserInfoDto userInfo)
    {
        if (await _userInfoRepository.AnyAsync(a => a.AccountNumber == userInfo.AccountNumber))
            throw new BusinessException("已经存在相同账号！");

        var data=ObjectMapper.Map<UserInfoDto,UserInfo>(userInfo);
        data =await _userInfoRepository.InsertAsync(data);

        return ObjectMapper.Map<UserInfo,UserInfoDto>(data);
    }

    public async Task DeleteUserInfoAsync(Guid userId)
    {
        if (_principalAccessor.UserId() == userId)
            throw new BusinessException("无法完成操作");

        await _userInfoRepository.DeleteAsync(userId);

    }

    public async Task<(UserInfoDto,string)> GetUserInfo(LoginInput input)
    {
        var data=await _userInfoRepository
            .GetAsync(a=>a.AccountNumber==input.AccountNumber&&a.Password== input.Password);

        if (data == null)
            throw new BusinessException("账号或者密码错误");

        var token=await _principalAccessor.CreateTokenAsync(data);

        return (ObjectMapper.Map<UserInfo,UserInfoDto>(data),token);
    }

    public async Task<List<DepartmentDto>> GetUserInfoDepartmentList(Guid userId)
    {
        var data = await _userInfoRepository.GetAsync(a => a.Id == userId);
        var departments=data.Department;
        return ObjectMapper.Map<List<Department>,List<DepartmentDto>>(departments);
    }

    public async Task<Tuple<List<UserInfoDto>, int>> GetUserInfoPaging(string? code, DateTime? startTime, DateTime? endTime, sbyte status = -1, int pageNo = 1, int pageSize = 20)
    {
        var data = await _userInfoRepository.GetListAsync(startTime,endTime,code,status,pageNo,pageSize);

        return new Tuple<List<UserInfoDto>, int>(ObjectMapper.Map<List<UserInfo>,List<UserInfoDto>>(data.Item1),data.Item2);
    }

    public async Task<UserInfoDto> UpdateUserInfo(UserInfoDto userInfo)
    {
        var data=await _userInfoRepository.FirstOrDefaultAsync(a=>a.Id==userInfo.Id);
        if (data == null)
            throw new BusinessException("用户不存在或者已经被删除");

        data.Name = userInfo.Name;
        data.Status = userInfo.Statue;
        data.Sex =(SexEnum) userInfo.Sex;
        data.MobileNumber = userInfo.MobileNumber;
        data.EMail=userInfo.EMail;
        await _userInfoRepository.UpdateAsync(data);


        return ObjectMapper.Map<UserInfo,UserInfoDto>(data);
    }
}
