using Microsoft.AspNetCore.Mvc.Filters;
using Token.Management.Domain;

namespace Token.HttpApi.Authoritys;

/// <summary>
///     权限验证
/// </summary>
public class AuthorizationAttribute : ActionFilterAttribute
{
    public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string? token = context.HttpContext.Request.Headers["Authorization"].ToString();
        if (token.IsNullOrWhiteSpace())
        {
            throw new BusinessException(401, "未登录");
        }

        // 获取当前用户角色
        // var list = context.HttpContext.User.Claims.Where(x => x.Type == Constants.Role).Select(x => x.Value).ToList();

        return base.OnActionExecutionAsync(context, next);
    }
}
