using ProgramsLauncher.Core;

namespace ProgramsLauncher;

public partial class ProfileEditorForm : Form
{
    private readonly IProfilesEditorModel _editorModel;

    public ProfileEditorForm(IProfilesEditorModel editorModel)
    {
        _editorModel = editorModel;
        
        InitializeComponent();

        _editorModel.ProfilesListUpdate += OnProfilesListUpdated;
        _editorModel.CurrentProfileItemsUpdate += OnCurrentProfileItemsUpdated;
        
        _editorModel.Initialize();
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        
        _editorModel.ProfilesListUpdate -= OnProfilesListUpdated;
        _editorModel.CurrentProfileItemsUpdate -= OnCurrentProfileItemsUpdated;
    }

    private void OnCurrentProfileItemsUpdated(object? sender, List<string> apps)
    {
        ProgramsListBox.Items.Clear();
        foreach (var app in apps)
        {
            ProgramsListBox.Items.Add(app);
        }
    }

    private void OnProfilesListUpdated(object? sender, ProfilesListUpdateEventArgs args)
    {
        ProfilesComboBox.Items.Clear();

        foreach (var profile in args.ProfilesNames)
        {
            ProfilesComboBox.Items.Add(profile);
        }

        ProfilesComboBox.SelectedIndex = args.SelectedProfileIndex;
    }
    
    private void ProfilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
         _editorModel.SelectProfile(ProfilesComboBox.SelectedIndex);
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

        _editorModel.AddNewApp(appName, appPath);

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
        _editorModel.Save();
        MessageBox.Show("Configuration saved successfully.", "Save Config", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void RemoveProgramButton_Click(object sender, EventArgs e)
    {
       _editorModel.RemoveApp(ProgramsListBox.SelectedIndex);
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

        _editorModel.AddProfile(profileName);
        ProfileNameTextBox.Clear();
    }

    private void DeleteProfileButton_Click(object sender, EventArgs e)
    {
        int index = ProfilesComboBox.SelectedIndex;
        if (index < 0)
        {
            MessageBox.Show("Select profile to delete.");
            return;
        }

        //add message box confirmation
        var result = MessageBox.Show(
            $"Are you sure you want to delete the profile '{_editorModel.CurrentProfile.Name}'?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            _editorModel.DeleteProfile();
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
        _editorModel.RenameProfile(newName);

        ProfileNameTextBox.Clear();
    }
}