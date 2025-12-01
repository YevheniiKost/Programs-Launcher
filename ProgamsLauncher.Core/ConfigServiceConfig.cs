namespace ProgramsLauncher.Core;

public class ConfigServiceConfig
{
    public readonly string AppFolderPath;
    public readonly string SaveFileName;

    public ConfigServiceConfig(string appFolderPath, string saveFileName)
    {
        AppFolderPath = appFolderPath;
        SaveFileName = saveFileName;
    }
}