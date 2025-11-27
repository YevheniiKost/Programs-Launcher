using System.Diagnostics;

namespace ProgramsLauncher;

public static class LauncherService
{
    public static void LaunchApplications(IEnumerable<AppEntry> apps)
    {
        foreach (AppEntry app in apps)
        {
            try
            {
                if(IsAppRunning(app))
                    continue;
                
                Process.Start(new ProcessStartInfo
                {
                    FileName = app.Path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to start \"{app.Name}\" ({app.Path}): {ex.Message}",
                    "Launch error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    public static bool IsAppRunning(AppEntry app)
    {
        var processName = Path.GetFileNameWithoutExtension(app.Path);

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