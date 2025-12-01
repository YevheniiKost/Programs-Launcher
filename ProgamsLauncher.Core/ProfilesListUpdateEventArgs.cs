namespace ProgramsLauncher.Core;

public class ProfilesListUpdateEventArgs : EventArgs
{
    public List<string> ProfilesNames { get; }
    public int SelectedProfileIndex { get; }

    public ProfilesListUpdateEventArgs(List<string> profilesNames,
        int selectedProfileIndex)
    {
        ProfilesNames = profilesNames;
        SelectedProfileIndex = selectedProfileIndex;
    }
}