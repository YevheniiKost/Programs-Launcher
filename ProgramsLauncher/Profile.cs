namespace ProgramsLauncher;

public class Profile
{
    public string Name { get; set; }
    public List<AppEntry> Applications { get; set; } = new();
}