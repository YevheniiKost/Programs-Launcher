using ProgramsLauncher.Core;

namespace ProgramsLauncher;

public partial class Form1 : Form
{
    private readonly IProgramsLauncherModel _model;
    private readonly IAutostartService _autostartService;
    private readonly IProfileEditorFormFactory _profileEditorFormFactory;

    public Form1(IProgramsLauncherModel model, IAutostartService autostartService,
        IProfileEditorFormFactory profileEditorFormFactory)
    {
        _model = model;
        _autostartService = autostartService;
        _profileEditorFormFactory = profileEditorFormFactory;
        InitializeComponent();

        _model.CurrentProfileItemsUpdate += OnCurrentProfileItemsUpdate;
        _model.ProfilesListUpdate += OnProfilesListUpdate;
        
        _model.Initialize();

        AutostartCheckBox.Checked = _autostartService.Enabled;
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        
        _model.CurrentProfileItemsUpdate -= OnCurrentProfileItemsUpdate;
        _model.ProfilesListUpdate -= OnProfilesListUpdate;
    }

    private void OnProfilesListUpdate(object? sender, List<string> profiles)
    {
        ProfilesComboBox.Items.Clear();
        foreach (var profile in profiles)
        {
            ProfilesComboBox.Items.Add(profile);
        }
    }

    private void OnCurrentProfileItemsUpdate(object? sender, List<string> programsList)
    {
        ProgramsListBox.Items.Clear();
        foreach (string app in programsList)
        {
            ProgramsListBox.Items.Add(app);
        }
    }

    private void RunAllButton_Click(object sender, EventArgs eventArgs)
    {
        try
        {
            _model.RunAll();
        }
        catch (LaunchAppException launchAppException)
        {
            MessageBox.Show(
                launchAppException.Message,
                "Launch error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void AutostartCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            _autostartService.Enabled = AutostartCheckBox.Checked;
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
        _model.SelectProfile(ProfilesComboBox.SelectedIndex);
    }

    private void EditProfilesButton_Click(object sender, EventArgs e)
    {
        ProfileEditorForm editorForm = _profileEditorFormFactory.Create();
        
        editorForm.FormClosed += (s, args) =>
        {
            _model.OnConfigUpdated();
        };
        editorForm.ShowDialog();
    }
}