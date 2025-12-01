namespace ProgramsLauncher.Core;

public interface ILauncherService
{
    void LaunchApplications(IEnumerable<AppEntry> apps);
}