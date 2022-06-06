namespace Token.HttpApi.Module;

/// <summary>
///     token Options Module
/// </summary>
public class TokenOptions
{
    /// <summary>
    ///     key
    /// </summary>
    public string SecretKey { get; set; }

    /// <summary>
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    ///     过期时间
    /// </summary>
    public int ExpireMinutes { get; set; } = 30;
}
