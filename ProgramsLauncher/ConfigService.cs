using System.Text.Json;

namespace ProgramsLauncher;

public static class ConfigService
{
    private static string GetConfigPath()
    {
        return Path.Combine(EternalConfig.AppFolderPath, "profiles.json");
    }

    public static ProfilesConfig? LoadConfig()
    {
        var path = GetConfigPath();
        if (!File.Exists(path))
            return null;

        try
        {
            var json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<ProfilesConfig>(json);
            return config;
        }
        catch
        {
            Logger.Log("Failed to load or parse the configuration file.");
            return null;
        }
    }

    public static void SaveConfig(ProfilesConfig config)
    {
        var path = GetConfigPath();
        var json = JsonSerializer.Serialize(config, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(path, json);
    }
}