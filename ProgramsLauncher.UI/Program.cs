using ProgramsLauncher.Core;
using ProgramsLauncher.Core.Logger;

namespace ProgramsLauncher;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        ILogger logger = new Logger(EternalConfig.AppFolderPath);

        IConfigService configService =
            new ConfigService(new ConfigServiceConfig(EternalConfig.AppFolderPath, "profiles.json"),
                new SystemFileStorage(), logger);
        
        ILauncherService launcherService = new LauncherService(logger);
        
        IAutostartService autostartService = new AutostartService(new AutostartServiceConfig(Application.ExecutablePath,
            @"Software\Microsoft\Windows\CurrentVersion\Run",
            "ProgramsLauncher"));
        
        IProfileEditorFormFactory profileEditorModelFactory = new ProfileEditorFormFactory(
                new ProfilesEditorModel(configService, logger));

        IProgramsLauncherModel programsLauncherModel = new ProgramsLauncherModel(configService, launcherService, logger);
        Application.Run(new Form1(programsLauncherModel, autostartService, profileEditorModelFactory));
    }
}