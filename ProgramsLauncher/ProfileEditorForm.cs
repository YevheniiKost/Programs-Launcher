namespace ProgramsLauncher;

public partial class ProfileEditorForm : Form
{
    private ProfilesConfig _config;
    private Profile _currentProfile;

    public ProfileEditorForm()
    {
        InitializeComponent();

        _config = ConfigService.LoadConfig();
        _currentProfile = _config.Profiles[0];

        RefreshProfilesList();
    }

    private void RefreshProgramsList()
    {
        ProgramsListBox.Items.Clear();
        foreach (var app in _currentProfile.Applications)
        {
            ProgramsListBox.Items.Add(app.Name);
        }
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
            ProfilesComboBox.SelectedIndex = _config.Profiles.IndexOf(_currentProfile);
            RefreshProgramsList();
        }
    }

    private void ProfilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ProfilesComboBox.SelectedIndex < 0) return;

        _currentProfile = _config.Profiles[ProfilesComboBox.SelectedIndex];
        RefreshProgramsList();
    }

    private void AddProgramButton_Click(object sender, EventArgs e)
    {
        var appName = ProgramNameTextBox.Text.Trim();
        var appPath = ProgramPathTextBox.Text.Trim();

        if (string.IsNullOrEmpty(appName) || string.IsNullOrEmpty(appPath))
        {
            MessageBox.Show("Please enter both application name and path.", "Input Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        if (!File.Exists(appPath) && !appPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show(
                "Path must either point to an existing file or be a .exe available in PATH.",
                "Input Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        var newApp = new AppEntry(appName, appPath);

        _currentProfile.Applications.Add(newApp);
        RefreshProgramsList();
        ConfigService.SaveConfig(_config);

        ProgramNameTextBox.Clear();
        ProgramPathTextBox.Clear();
    }

    private void BrowseButton_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog();
        dialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
        dialog.Title = "Select application";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            ProgramNameTextBox.Clear();
            ProgramPathTextBox.Text = dialog.FileName;

            if (string.IsNullOrWhiteSpace(ProgramNameTextBox.Text))
            {
                ProgramNameTextBox.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
            }
        }
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        ConfigService.SaveConfig(_config);
        MessageBox.Show("Configuration saved successfully.", "Save Config", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void RemoveProgramButton_Click(object sender, EventArgs e)
    {
        int index = ProgramsListBox.SelectedIndex;
        if (index < 0)
        {
            MessageBox.Show("Select program to delete.");
            return;
        }

        _currentProfile.Applications.RemoveAt(index);
        ConfigService.SaveConfig(_config);
        RefreshProgramsList();
    }

    private void AddProfileButton_Click(object sender, EventArgs e)
    {
        var profileName = ProfileNameTextBox.Text.Trim();

        if (string.IsNullOrEmpty(profileName))
        {
            MessageBox.Show("Please enter a profile name.", "Input Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        var newProfile = new Profile
        {
            Name = profileName
        };

        _config.Profiles.Add(newProfile);
        _currentProfile = newProfile;
        RefreshProfilesList();
        ConfigService.SaveConfig(_config);

        ProfileNameTextBox.Clear();
    }

    private void DeleteProfileButton_Click(object sender, EventArgs e)
    {
        if (_config.Profiles.Count <= 1)
        {
            MessageBox.Show("At least one profile must exist.", "Delete Profile", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        int index = ProfilesComboBox.SelectedIndex;
        if (index < 0)
        {
            MessageBox.Show("Select profile to delete.");
            return;
        }

        //add message box confirmation
        var result = MessageBox.Show(
            $"Are you sure you want to delete the profile '{_config.Profiles[index].Name}'?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            _config.Profiles.RemoveAt(index);
            _currentProfile = _config.Profiles[0];
            RefreshProfilesList();
            ConfigService.SaveConfig(_config);
        }
    }

    private void RenameProfileButton_Click(object sender, EventArgs e)
    {
        int index = ProfilesComboBox.SelectedIndex;
        if (index < 0)
        {
            MessageBox.Show("Select profile to rename.");
            return;
        }

        var newName = ProfileNameTextBox.Text.Trim();
        if (string.IsNullOrEmpty(newName))
        {
            MessageBox.Show("Please enter a new profile name.", "Input Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        _config.Profiles[index].Name = newName;
        RefreshProfilesList();
        ConfigService.SaveConfig(_config);

        ProfileNameTextBox.Clear();
    }
}