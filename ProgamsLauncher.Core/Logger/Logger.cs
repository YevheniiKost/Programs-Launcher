namespace ProgramsLauncher.Core.Logger;

public class Logger : ILogger
{
    private  string _folderPath;

    public Logger(string folderPath)
    {
        _folderPath = folderPath;
    }

    public void Log(string message, LogType type = LogType.Log)
    {
        var logPath = Path.Combine(_folderPath, "log.txt");
        var logMessage = $"{GetPrefix(type)} {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";

        File.AppendAllText(logPath, logMessage);
    }

    public void LogWarning(string message) => Log(message, LogType.Warning);
    public void LogError(string message) => Log(message, LogType.Error);

    private static string GetPrefix(LogType type)
    {
        return type switch
        {
            LogType.Log => "[Log]",
            LogType.Warning => "[Warning]",
            LogType.Error => "[Error]",
            _ => "[Unknown]"
        };
    }
}