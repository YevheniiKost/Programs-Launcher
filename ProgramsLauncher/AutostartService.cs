using Microsoft.Win32;

namespace ProgramsLauncher;

public static class AutostartService
{
    private const string RUN_KEY = @"Software\Microsoft\Windows\CurrentVersion\Run";
    private const string APP_NAME = "ProgramsLauncher";

    public static bool IsEnabled()
    {
        using var key = Registry.CurrentUser.OpenSubKey(RUN_KEY, writable: false);
        if (key == null) return false;

        var value = key.GetValue(APP_NAME) as string;
        return !string.IsNullOrEmpty(value);
    }

    public static void SetEnabled(bool enabled)
    {
        using var key = Registry.CurrentUser.OpenSubKey(RUN_KEY, writable: true)
                        ?? Registry.CurrentUser.CreateSubKey(RUN_KEY);

        if (enabled)
        {
            var exePath = Application.ExecutablePath;
            key.SetValue(APP_NAME, $"\"{exePath}\"");
        }
        else
        {
            key.DeleteValue(APP_NAME, false);
        }
    }
}