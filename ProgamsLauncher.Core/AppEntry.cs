namespace ProgramsLauncher.Core;

public class AppEntry(string name, string path)
{
    public string Name { get; } = name;
    public string Path { get; } = path;
}