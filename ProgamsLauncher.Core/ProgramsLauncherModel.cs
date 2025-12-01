using ProgramsLauncher.Core.Logger;

namespace ProgramsLauncher.Core;

public class ProgramsLauncherModel : IProgramsLauncherModel
{
    private readonly IConfigService _configService;
    private readonly ILauncherService _launcherService;
    private readonly ILogger _logger;
    
    private ProfilesConfig _config;
    private Profile _currentProfile;

    public ProgramsLauncherModel(IConfigService configService, ILauncherService launcherService, ILogger logger)
    {
        _configService = configService;
        _launcherService = launcherService;
        _logger = logger;
    }

    public event EventHandler<List<string>>? CurrentProfileItemsUpdate;
    public event EventHandler<List<string>>? ProfilesListUpdate;

    public void Initialize()
    {
        _config = _configService.LoadConfig();

        if (_config == null || _config.Profiles.Count == 0)
        {
            _currentProfile = new Profile
            {
                Name = "Main Profile"
            };

            _config = new ProfilesConfig();
            _config.Profiles.Add(_currentProfile);

            _configService.SaveConfig(_config);
        }
        else
        {
            _currentProfile = _config.Profiles[0];
        }
        
        RefreshProfilesList();
    }

    public void RunAll()
    {
        _launcherService.LaunchApplications(_currentProfile.Applications);
    }

    public void SelectProfile(int index)
    {
        if (index < 0 || index >= _config.Profiles.Count)
        {
            _logger.LogWarning($"ProgamsLauncherModel.SelectProfile Wrong index {index}");
            return;
        }

        _currentProfile = _config.Profiles[index];
        RefreshProgramsList();
    }

    public void OnConfigUpdated()
    {
        _config = _configService.LoadConfig();
        RefreshProfilesList();
    }

    private void RefreshProfilesList()
    {
        if (_config.Profiles.Count > 0)
        {
            _currentProfile = _config.Profiles[0];
            RefreshProgramsList();

            List<string> profilesNames = new List<string>();
            foreach (Profile profile in _config.Profiles)
            {
                profilesNames.Add(profile.Name);
            }
            ProfilesListUpdate?.Invoke(this, profilesNames);
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
}