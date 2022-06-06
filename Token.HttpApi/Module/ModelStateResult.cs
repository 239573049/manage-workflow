using Microsoft.AspNetCore.Mvc;

namespace GoYes.Module;

public class ModelStateResult : ActionResult
{
    public ModelStateResult()
    {
    }

    public ModelStateResult(string message, int code = 400)
    {
        Message = message;
        Code = code;
    }

    /// <summary>
    ///     状态码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    ///     错误信息
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    ///     数据
    /// </summary>
    public object? Data { get; set; }
}
