namespace ProgramsLauncher.Core.Logger;

public interface ILogger
{
    void Log(string message, LogType type = LogType.Log);
    void LogWarning(string message);
    void LogError(string message);
}