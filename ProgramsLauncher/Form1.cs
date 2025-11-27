namespace ProgramsLauncher;

public partial class Form1 : Form
{
    private ProfilesConfig _config;
    private Profile _currentProfile;

    public Form1()
    {
        InitializeComponent();

        _config = ConfigService.LoadConfig();

        if (_config == null || _config.Profiles.Count == 0)
        {
            _currentProfile = new Profile
            {
                Name = "Main Profile"
            };

            _config = new ProfilesConfig();
            _config.Profiles.Add(_currentProfile);

            ConfigService.SaveConfig(_config);
        }
        else
        {
            _currentProfile = _config.Profiles[0];
        }
        
        RefreshProfilesList();
        AutostartCheckBox.Checked = AutostartService.IsEnabled();
    }
    
    private void RefreshProfilesList()
    {
        ProfilesComboBox.Items.Clear();

        foreach (var profile in _config.Profiles)
        {
            ProfilesComboBox.Items.Add(profile.Name);
        }

        if (_config.Profiles.Count > 0)
        {
            ProfilesComboBox.SelectedIndex = 0;
            _currentProfile = _config.Profiles[0];
            RefreshProgramsList();
        }
    }
    
    private void RefreshProgramsList()
    {
        ProgramsListBox.Items.Clear();
        foreach (var app in _currentProfile.Applications)
        {
            ProgramsListBox.Items.Add(app.Name);
        }
    }
    
    private void RunAllButton_Click(object sender, EventArgs e)
    {
        LauncherService.LaunchApplications(_currentProfile.Applications);
    }
    
    private void AutostartCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            AutostartService.SetEnabled(AutostartCheckBox.Checked);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to change autostart setting: {ex.Message}",
                "Autostart Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            AutostartCheckBox.CheckedChanged -= AutostartCheckBox_CheckedChanged;
            AutostartCheckBox.Checked = !AutostartCheckBox.Checked;
            AutostartCheckBox.CheckedChanged += AutostartCheckBox_CheckedChanged;
        }
    }

    private void ProfilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ProfilesComboBox.SelectedIndex < 0) return;

        _currentProfile = _config.Profiles[ProfilesComboBox.SelectedIndex];
        RefreshProgramsList();
    }

    private void EditProfilesButton_Click(object sender, EventArgs e)
    {
        var editorForm = new ProfileEditorForm();
        editorForm.FormClosed += (s, args) =>
        {
            _config = ConfigService.LoadConfig();
            RefreshProfilesList();
        };
        editorForm.ShowDialog();
    }
}