namespace ProgramsLauncher;

public static class EternalConfig
{
    public static string AppFolderPath
    {
        get
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appFolder = Path.Combine(appData, "ProgramsLauncher");

            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);

            return appFolder;
        }
    }
}