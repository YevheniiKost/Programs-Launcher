using ProgramsLauncher.Core.Logger;

namespace ProgramsLauncher.Core;

public class ProfilesEditorModel : IProfilesEditorModel
{
    private readonly IConfigService _configService;
    private readonly ILogger _logger;
    
    private ProfilesConfig _config;
    private Profile? _currentProfile;

    public ProfilesEditorModel(IConfigService configService, ILogger logger)
    {
        _configService = configService;
        _logger = logger;
    }

    public Profile CurrentProfile => _currentProfile;
    
    public event EventHandler<List<string>>? CurrentProfileItemsUpdate;
    public event EventHandler<ProfilesListUpdateEventArgs>? ProfilesListUpdate;
    
    public void Initialize()
    {
        _config = _configService.LoadConfig();
        _currentProfile = _config.Profiles[0];
        
        RefreshProfilesList();
    }
    
    private void RefreshProfilesList()
    {
        if (_config.Profiles.Count > 0)
        {
            if (_currentProfile == null)
            {
                _currentProfile = _config.Profiles[0];
            }

            RefreshProgramsList();

            List<string> profilesNames = new List<string>();
            foreach (Profile profile in _config.Profiles)
            {
                profilesNames.Add(profile.Name);
            }
            int index = _config.Profiles.IndexOf(_currentProfile);
            ProfilesListUpdate?.Invoke(this, new ProfilesListUpdateEventArgs(profilesNames, index));
        }
    }
    
    private void RefreshProgramsList()
    {
        List<string> appNames = new List<string>();

        foreach (var app in _currentProfile.Applications)
        {
            appNames.Add(app.Name);
        }
        
        CurrentProfileItemsUpdate?.Invoke(this, appNames);
    }
    
    public void SelectProfile(int index)
    {
        if (index < 0 || index >= _config.Profiles.Count)
        {
            _logger.LogWarning($"ProfileEditorModel.SelectProfile Wrong index {index}");
            return;
        }

        _currentProfile = _config.Profiles[index];
        RefreshProgramsList();
    }

    public void AddProfile(string name)
    {
        Profile newProfile = new Profile
        {
            Name = name
        };

        _config.Profiles.Add(newProfile);
        _currentProfile = newProfile;
        _configService.SaveConfig(_config);
        RefreshProfilesList();
    }

    public void RenameProfile(string newName)
    {
        _currentProfile.Name = newName;
        RefreshProfilesList();
        _configService.SaveConfig(_config);
    }

    public void DeleteProfile()
    {
        if(_config.Profiles.Count <= 1)
        {
            _logger.LogWarning("ProfileEditorModel.DeleteProfile Cannot delete the last profile");
            return;
        }
        
        int index = _config.Profiles.IndexOf(_currentProfile);
        
        _config.Profiles.RemoveAt(index);
        _currentProfile = _config.Profiles[0];
        _configService.SaveConfig(_config);
        RefreshProfilesList();
    }

    public void AddNewApp(string name, string path)
    {
        AppEntry newApp = new AppEntry(name, path);

        _currentProfile.Applications.Add(newApp);
        RefreshProgramsList();
        _configService.SaveConfig(_config);
    }

    public void RemoveApp(int index)
    {
        if (index < 0 || index >= _config.Profiles.Count)
        {
            _logger.LogWarning($"ProfileEditorModel.RemoveProgram Wrong index {index}");
            return;
        }
        
        _currentProfile.Applications.RemoveAt(index);
        _configService.SaveConfig(_config);
        
        RefreshProgramsList();
    }

    public void Save()
    {
        _configService.SaveConfig(_config);
    }
}