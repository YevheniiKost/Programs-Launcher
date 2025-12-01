using System.Diagnostics;
using ProgramsLauncher.Core.Log;

namespace ProgramsLauncher.Core;

public class LauncherService : ILauncherService
{
    private readonly ILogger _logger;

    public LauncherService(ILogger logger)
    {
        _logger = logger;
    }
    
    public void LaunchApplications(IEnumerable<AppEntry> apps)
    {
        foreach (AppEntry app in apps)
        {
            try
            {
                if (IsAppRunning(app))
                    continue;

                Process.Start(new ProcessStartInfo
                {
                    FileName = app.Path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to launch app {app.Name}: {ex} {ex.Message}");
                throw new LaunchAppException(app);
            }
        }
    }

    private static bool IsAppRunning(AppEntry app)
    {
        string processName = Path.GetFileNameWithoutExtension(app.Path);

        foreach (var process in Process.GetProcessesByName(processName))
        {
            try
            {
                string path = process.MainModule?.FileName;
                if (path != null &&
                    Path.GetFullPath(path).Equals(Path.GetFullPath(app.Path), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            catch
            {
                // Пропускаємо процеси, до яких немає доступу
            }
        }

        return false;
    }
}