using System.Text.Json;
using JetBrains.Annotations;
using ProgramsLauncher.Core;

namespace ProgramsLauncher.Tests;

[TestSubject(typeof(ConfigService))]
public class ConfigServiceTests
{
    private ConfigService CreateService(FakeFileStorage fs, string folder = "C:\\App", string file = "config.json")
    {
        var cfg = new ConfigServiceConfig(folder, file);
        var logger = new FakeLogger();
        return new ConfigService(cfg, fs, logger);
    }

    // -----------------------------
    // LOAD TESTS
    // -----------------------------

    [Fact]
    public void LoadConfig_ReturnsNull_WhenFileDoesNotExist()
    {
        // Arrange
        var fs = new FakeFileStorage { FileExists = false };
        var service = CreateService(fs);

        // Act
        var result = service.LoadConfig();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LoadConfig_ReturnsParsedObject_WhenJsonIsValid()
    {
        // Arrange
        var expectedConfig = new ProfilesConfig
        {
            Profiles = new List<Profile>
            {
                new Profile { Name = "TestProfile", Applications = new List<AppEntry>
                {
                    new AppEntry("App1", "C:\\App1.exe"),
                    new AppEntry("App2", "C:\\App2.exe")
                }}
            }
        };

        var json = JsonSerializer.Serialize(expectedConfig);

        var fs = new FakeFileStorage
        {
            FileExists = true,
            LoadContentToReturn = json
        };

        var service = CreateService(fs);

        // Act
        var result = service.LoadConfig();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result!.Profiles);
        Assert.Equal("TestProfile", result.Profiles[0].Name);
        Assert.Equal(2, result.Profiles[0].Applications.Count);
    }

    [Fact]
    public void LoadConfig_ReturnsNull_WhenJsonIsInvalid()
    {
        // Arrange
        var fs = new FakeFileStorage
        {
            FileExists = true,
            LoadContentToReturn = "{ invalid json"
        };

        var service = CreateService(fs);

        // Act
        var result = service.LoadConfig();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LoadConfig_ReturnsNull_WhenLoadThrows()
    {
        // Arrange
        var fs = new FakeFileStorage
        {
            FileExists = true,
            ThrowOnLoad = true
        };

        var service = CreateService(fs);

        // Act
        var result = service.LoadConfig();

        // Assert
        Assert.Null(result);
    }

    // -----------------------------
    // SAVE TESTS
    // -----------------------------

    [Fact]
    public void SaveConfig_SerializesObjectAndWritesToFile()
    {
        // Arrange
        var fs = new FakeFileStorage();
        var service = CreateService(fs);

        var config = new ProfilesConfig
        {
            Profiles = new List<Profile>
            {
                new Profile { Name = "SaveTest", Applications = new List<AppEntry>
                {
                    new AppEntry("AppSave", "C:\\AppSave.exe")
                }}
            }
        };

        // Act
        service.SaveConfig(config);

        // Assert
        Assert.Equal("C:\\App\\config.json", fs.SavedPath);
        Assert.NotNull(fs.SavedContent);

        // Перевіримо, що JSON містить наш профіль
        Assert.Contains("SaveTest", fs.SavedContent!);
    }
}