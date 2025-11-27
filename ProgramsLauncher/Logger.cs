namespace ProgramsLauncher;

public static class Logger
{
    public static void Log(string message)
    {
        var logPath = Path.Combine(EternalConfig.AppFolderPath, "log.txt");
        var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";

        File.AppendAllText(logPath, logMessage);
    }
}