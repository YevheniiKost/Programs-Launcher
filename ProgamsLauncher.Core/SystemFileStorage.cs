namespace ProgramsLauncher.Core;

public class SystemFileStorage : IFileStorage
{
    public void Save(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    public string Load(string path)
    {
        return File.ReadAllText(path);
    }

    public bool Exists(string path)
    {
        return File.Exists(path);
    }
}