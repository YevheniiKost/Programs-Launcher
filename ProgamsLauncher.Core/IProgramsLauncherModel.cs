namespace ProgramsLauncher.Core;

public interface IProgramsLauncherModel
{
    event EventHandler<List<string>> CurrentProfileItemsUpdate;
    event EventHandler<List<string>> ProfilesListUpdate;
    
    void Initialize();

    void RunAll();
    void SelectProfile(int index);
    void OnConfigUpdated();
}