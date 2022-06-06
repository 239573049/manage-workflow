namespace Token.Infrastructure.Extension;

public static class StringExtension
{
    /// <summary>
    /// 判断字符串是否为空
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNull(this string? value)
    {
        return string.IsNullOrEmpty(value);
    }
}
