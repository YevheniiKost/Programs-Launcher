using System.Text.Json;
using ProgramsLauncher.Core.Logger;

namespace ProgramsLauncher.Core;

public class ConfigService : IConfigService
{
    private readonly ConfigServiceConfig _config;
    private readonly IFileStorage _fileStorage;
    private readonly ILogger _logger;

    public ConfigService(ConfigServiceConfig config, IFileStorage fileStorage, ILogger logger)
    {
        _config = config;
        _fileStorage = fileStorage;
        _logger = logger;
    }

    private string GetConfigPath()
    {
        return Path.Combine(_config.AppFolderPath, _config.SaveFileName);
    }

    public ProfilesConfig? LoadConfig()
    {
        var path = GetConfigPath();
        
        if (!_fileStorage.Exists(path))
            return null;

        try
        {
            string json = _fileStorage.Load(path);
            ProfilesConfig? config = JsonSerializer.Deserialize<ProfilesConfig>(json);
            return config;
        }
        catch
        {
            _logger.Log("Failed to load or parse the configuration file.");
            return null;
        }
    }

    public void SaveConfig(ProfilesConfig config)
    {
        var path = GetConfigPath();
        var json = JsonSerializer.Serialize(config, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        _fileStorage.Save(path, json);
    }
}