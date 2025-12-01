namespace ProgramsLauncher.Core;

public interface IProfilesEditorModel
{
    event EventHandler<List<string>> CurrentProfileItemsUpdate;
    event EventHandler<ProfilesListUpdateEventArgs> ProfilesListUpdate;

    Profile CurrentProfile { get; }
    
    void Initialize();
    void SelectProfile(int index);
    void AddProfile(string name);
    void RenameProfile(string newName);
    void DeleteProfile();
    void AddNewApp(string name, string path);
    void RemoveApp(int index);
    void Save();
}