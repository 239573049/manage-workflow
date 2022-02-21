using Microsoft.AspNetCore.Mvc;

namespace Management.WebCore.Model;

public class ModelStateResult: ActionResult
{
    /// <summary>
    /// 状态码
    /// </summary>
    public int StatusCode { get; set; }
    /// <summary>
    /// 错误信息
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// 数据
    /// </summary>
    public object? Data { get; set; }

    public ModelStateResult()
    {
    }

    public ModelStateResult(string message, int statusCode = 400)
    {
        Message = message;
        StatusCode = statusCode;
    }
}
