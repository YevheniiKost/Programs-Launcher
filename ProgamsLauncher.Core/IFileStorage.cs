namespace ProgramsLauncher.Core;

public interface IFileStorage
{
    void Save(string path, string content);
    string Load(string path);

    bool Exists(string path);
}