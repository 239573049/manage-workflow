namespace Token.Management.Domain;

/// <summary>
/// 业务异常
/// </summary>
public class BusinessException : Exception
{
    /// <inheritdoc/>
    public BusinessException()
    {
    }

    /// <inheritdoc/>
    public BusinessException(string message) : base(message)
    {
    }

    /// <inheritdoc/>
    public BusinessException(int code, string? message) : base(message)
    {
        Code = code;
    }

    /// <summary>
    ///     异常状态码
    /// </summary>
    public int Code { get; set; }
}
