using Microsoft.Extensions.Configuration;

namespace Cstati.Events.Workflows.GenericSubdomain.Configuration;

public static class ConfigurationValueFetcher
{
    public static string GetRequiredString(IConfiguration configuration, string key)
    {
        var result = GetRequired<string>(configuration, key);

        return result;
    }

    public static T GetRequired<T>(IConfiguration configuration)
    {
        string key = typeof(T).Name;

        var result = GetRequired<T>(configuration, key);

        return result;
    }

    private static T GetRequired<T>(IConfiguration configuration, string key)
    {
        IConfigurationSection section = configuration.GetRequiredSection(key);

        var result = section.Get<T>();

        if (result is null)
        {
            throw new ApplicationException($"Configuration has no value for a required key '{key}'.");
        }

        return result;
    }
}
