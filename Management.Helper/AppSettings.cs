using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Management.Helper;

public class AppSettings
{
    private static IConfiguration? Configuration
    {
        get;
        set;
    }
    public AppSettings(string contentPath, string path = "appsettings.json")
    {
        Configuration = new ConfigurationBuilder().SetBasePath(contentPath).Add(new JsonConfigurationSource
        {
            Path = path,
            Optional = false,
            ReloadOnChange = true
        }).Build();
    }

    public static string App(params string[] sections)
    {
        try
        {
            if (sections.Any())
            {
                return Configuration == null ? "" : Configuration[string.Join(":", sections)];
            }
        }
        catch (Exception)
        {
        }

        return "";
    }
}
