namespace Token.Management.Domain;

public class BusinessException : Exception
{
    public BusinessException()
    {
    }

    public BusinessException(string message) : base(message)
    {
        Message = message;
    }

    public BusinessException(int code, string? message) : base(message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    ///     异常状态码
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    ///     异常详细
    /// </summary>
    public string? Message { get; set; }
}
