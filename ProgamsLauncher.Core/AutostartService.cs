using Microsoft.Win32;

namespace ProgramsLauncher.Core;

public interface IAutostartService
{
    bool Enabled { get; set; }
}

public class AutostartServiceConfig
{
    public readonly string RunKey;
    public readonly string AppName;
    public readonly string ApplicationExecutablePath;
    
    public AutostartServiceConfig(string applicationExecutablePath, string runKey = @"Software\Microsoft\Windows\CurrentVersion\Run", string appName = "ProgramsLauncher")
    {
        ApplicationExecutablePath = applicationExecutablePath;
        RunKey = runKey;
        AppName = appName;
    }
}

public class AutostartService : IAutostartService
{
    private readonly AutostartServiceConfig _config;

    public AutostartService(AutostartServiceConfig config)
    {
        _config = config;
    }

    public bool Enabled
    {
        get => IsEnabled();
        set => SetEnabled(value);
    }

    private bool IsEnabled()
    {
        using var key = Registry.CurrentUser.OpenSubKey(_config.RunKey, writable: false);
        if (key == null) return false;

        var value = key.GetValue(_config.AppName) as string;
        return !string.IsNullOrEmpty(value);
    }

    private void SetEnabled(bool enabled)
    {
        using var key = Registry.CurrentUser.OpenSubKey(_config.RunKey, writable: true)
                        ?? Registry.CurrentUser.CreateSubKey(_config.RunKey);

        if (enabled)
        {
            string exePath = _config.ApplicationExecutablePath;
            key.SetValue(_config.AppName, $"\"{exePath}\"");
        }
        else
        {
            key.DeleteValue(_config.AppName, false);
        }
    }
}