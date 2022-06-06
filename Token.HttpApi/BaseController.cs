using Microsoft.AspNetCore.Mvc;

namespace Token.HttpApi;

[Route("api/[controller]/[action]")]
[ApiController]
public class BaseController : ControllerBase
{
    public string Token => HttpContext.Request.Headers["Authorization"].ToString();
}
