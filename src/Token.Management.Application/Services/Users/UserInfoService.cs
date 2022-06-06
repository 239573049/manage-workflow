using AutoMapper;
using Management.Application.Services.Management;
using Token.HttpApi;
using Token.Management.Application.Contracts.AppServices.Users;
using Token.Management.Application.Contracts.Module.Management;
using Token.Management.Application.Contracts.Module.Users;
using Token.Management.Domain;
using Token.Management.Domain.Shared;
using Token.Management.Domain.Users;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Token.Management.Application.Services.Users;

public class UserInfoService : ApplicationService, IUserInfoService
{
    private readonly IMapper _mapper;
    private readonly IPrincipalAccessor _principalAccessor;
    private readonly IDepartmentService _departmentService;
    private readonly IUserInfoRepository _userInfoRepository;
    public UserInfoService(
        IMapper mapper,
        IDepartmentService departmentService,
        IPrincipalAccessor principalAccessor, IUserInfoRepository userInfoRepository)
    {
        _mapper = mapper;
        _departmentService = departmentService;
        _principalAccessor = principalAccessor;
        _userInfoRepository = userInfoRepository;
    }

    public async Task<UserInfoDto> CreateUserInfo(UserInfoDto userInfo)
    {
        if (await _userInfoRepository.AnyAsync(a => a.AccountNumber == userInfo.AccountNumber))
            throw new BusinessException("已经存在相同账号！");

        var data=_mapper.Map<UserInfo>(userInfo);
        data =await _userInfoRepository.InsertAsync(data);

        return _mapper.Map<UserInfoDto>(data);
    }

    public async Task DeleteUserInfoAsync(Guid userId)
    {
        if (_principalAccessor.UserId() == userId)
            throw new BusinessException("无法完成操作");

        await _userInfoRepository.DeleteAsync(userId);

    }

    public async Task<UserInfoDto> GetUserInfo(LoginInput input)
    {
        var data=await _userInfoRepository
            .GetAsync(a=>a.AccountNumber==input.AccountNumber&&a.Password==input.Password);

        if (data == null)
            throw new BusinessException("账号或者密码错误");

        return _mapper.Map<UserInfoDto>(data);
    }

    public async Task<List<DepartmentDto>> GetUserInfoDepartmentList(Guid userId)
    {
        var data = await _userInfoRepository.GetAsync(a => a.Id == userId);

        return _mapper.Map<List<DepartmentDto>>(data);
    }

    public async Task<Tuple<List<UserInfoDto>, int>> GetUserInfoPaging(string? code, DateTime? startTime, DateTime? endTime, sbyte statue = -1, int pageNo = 1, int pageSize = 20)
    {
        var data = await _userInfoRepository
            .GetListAsync(a => a.CreationTime > startTime && a.CreationTime < endTime &&
                               (string.IsNullOrEmpty(code) || a.Name.ToLower().Contains(code)) &&
                               (statue == -1 || (StatueEnum)statue == a.Statue),
            a => a.CreationTime,pageNo,pageSize);

        return new Tuple<List<UserInfoDto>, int>(_mapper.Map<List<UserInfoDto>>(data.Item1),data.Item2);
    }

    public async Task<UserInfoDto> UpdateUserInfo(UserInfoDto userInfo)
    {
        var data=await _userInfoRepository.FirstOrDefaultAsync(a=>a.Id==userInfo.Id);
        if (data == null)
            throw new BusinessException("用户不存在或者已经被删除");

        data.Name = userInfo.Name;
        data.Statue = userInfo.Statue;
        data.Sex =(SexEnum) userInfo.Sex;
        data.MobileNumber = userInfo.MobileNumber;
        data.EMail=userInfo.EMail;
        await _userInfoRepository.UpdateAsync(data);


        return _mapper.Map<UserInfoDto>(data);
    }
}
