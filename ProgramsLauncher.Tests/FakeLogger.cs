using ProgramsLauncher.Core.Logger;

namespace ProgramsLauncher.Tests;

public class FakeLogger : ILogger
{
    public void Log(string message, LogType type = LogType.Log)
    {
    }

    public void LogWarning(string message)
    {
    }

    public void LogError(string message)
    {
    }
}