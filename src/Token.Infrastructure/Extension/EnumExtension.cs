using System.ComponentModel;
using System.Reflection;

namespace Token.Infrastructure.Extension;

/// <summary>
/// 枚举扩展方法
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// 获取枚举特性注释
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static string? GetEnumString(this Enum enumValue)
    {
        return enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? null;
    }


    /// <summary>
    /// 注释转换枚举
    /// </summary>
    /// <typeparam name="T">枚举</typeparam>
    /// <param name="enumValue">注释</param>
    /// <returns></returns>
    public static T? GetEnumVal<T>(this string enumValue)
    {
        foreach (var field in typeof(T).GetFields())
        {
            var enumStringValue = field.CustomAttributes.FirstOrDefault()?.ConstructorArguments.FirstOrDefault().Value?.ToString();
            if (enumStringValue.IsNullOrWhiteSpace())continue;
            if (enumStringValue == enumValue)
            {
                return (T)Enum.Parse(typeof(T), field.GetValue(null)?.ToString() ?? string.Empty);
            }
        }
        return default;
    }
}
