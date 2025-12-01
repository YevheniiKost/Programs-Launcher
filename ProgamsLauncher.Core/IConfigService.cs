namespace ProgramsLauncher.Core;

public interface IConfigService
{
    ProfilesConfig? LoadConfig();
    void SaveConfig(ProfilesConfig config);
}