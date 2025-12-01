using ProgramsLauncher.Core;

namespace ProgramsLauncher.Tests;

public class FakeFileStorage : IFileStorage
{
    public bool FileExists { get; set; } = false;
    public string? SavedPath { get; private set; }
    public string? SavedContent { get; private set; }
    public string? LoadedPath { get; private set; }
    public string? LoadContentToReturn { get; set; } = null;

    public bool ThrowOnLoad { get; set; } = false;

    public void Save(string path, string content)
    {
        SavedPath = path;
        SavedContent = content;
        FileExists = true;
    }

    public string Load(string path)
    {
        if (ThrowOnLoad)
            throw new Exception("Simulated file load failure");

        LoadedPath = path;
        return LoadContentToReturn!;
    }

    public bool Exists(string path) => FileExists;
}