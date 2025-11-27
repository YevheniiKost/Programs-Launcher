using System.ComponentModel;

namespace ProgramsLauncher;

partial class ProfileEditorForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        AddProgramButton = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        ProfilesComboBox = new System.Windows.Forms.ComboBox();
        listBox1 = new System.Windows.Forms.ListBox();
        SelectProfileLabel = new System.Windows.Forms.Label();
        ProgramsListBox = new System.Windows.Forms.ListBox();
        AddProfileButton = new System.Windows.Forms.Button();
        DeleteProfileButton = new System.Windows.Forms.Button();
        RenameProfileButton = new System.Windows.Forms.Button();
        ProgramNameTextBox = new System.Windows.Forms.TextBox();
        ProgramPathTextBox = new System.Windows.Forms.TextBox();
        AddProgramLabel = new System.Windows.Forms.Label();
        BrowseButton = new System.Windows.Forms.Button();
        RemoveProgramButton = new System.Windows.Forms.Button();
        SaveButton = new System.Windows.Forms.Button();
        CancelButton = new System.Windows.Forms.Button();
        ProfileNameTextBox = new System.Windows.Forms.TextBox();
        EnterProfileNameLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // AddProgramButton
        // 
        AddProgramButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)128)));
        AddProgramButton.Location = new System.Drawing.Point(266, 111);
        AddProgramButton.Name = "AddProgramButton";
        AddProgramButton.Size = new System.Drawing.Size(110, 30);
        AddProgramButton.TabIndex = 8;
        AddProgramButton.Text = "Add Program";
        AddProgramButton.UseVisualStyleBackColor = false;
        AddProgramButton.Click += AddProgramButton_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(30, 18);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(144, 21);
        label1.TabIndex = 12;
        label1.Tag = "";
        label1.Visible = false;
        // 
        // ProfilesComboBox
        // 
        ProfilesComboBox.FormattingEnabled = true;
        ProfilesComboBox.Location = new System.Drawing.Point(29, 42);
        ProfilesComboBox.Name = "ProfilesComboBox";
        ProfilesComboBox.Size = new System.Drawing.Size(197, 23);
        ProfilesComboBox.TabIndex = 12;
        ProfilesComboBox.SelectedIndexChanged += ProfilesComboBox_SelectedIndexChanged;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new System.Drawing.Point(30, 99);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(198, 124);
        listBox1.TabIndex = 2;
        listBox1.Visible = false;
        // 
        // SelectProfileLabel
        // 
        SelectProfileLabel.Location = new System.Drawing.Point(30, 12);
        SelectProfileLabel.Name = "SelectProfileLabel";
        SelectProfileLabel.Size = new System.Drawing.Size(196, 27);
        SelectProfileLabel.TabIndex = 13;
        SelectProfileLabel.Text = "Select profile";
        // 
        // ProgramsListBox
        // 
        ProgramsListBox.FormattingEnabled = true;
        ProgramsListBox.ItemHeight = 15;
        ProgramsListBox.Location = new System.Drawing.Point(30, 87);
        ProgramsListBox.Name = "ProgramsListBox";
        ProgramsListBox.Size = new System.Drawing.Size(197, 124);
        ProgramsListBox.TabIndex = 14;
        // 
        // AddProfileButton
        // 
        AddProfileButton.BackColor = System.Drawing.SystemColors.ControlDark;
        AddProfileButton.Location = new System.Drawing.Point(30, 266);
        AddProfileButton.Name = "AddProfileButton";
        AddProfileButton.Size = new System.Drawing.Size(91, 32);
        AddProfileButton.TabIndex = 15;
        AddProfileButton.Text = "Add Profile";
        AddProfileButton.UseVisualStyleBackColor = false;
        AddProfileButton.Click += AddProfileButton_Click;
        // 
        // DeleteProfileButton
        // 
        DeleteProfileButton.Location = new System.Drawing.Point(136, 266);
        DeleteProfileButton.Name = "DeleteProfileButton";
        DeleteProfileButton.Size = new System.Drawing.Size(91, 32);
        DeleteProfileButton.TabIndex = 16;
        DeleteProfileButton.Text = "Delete Profile";
        DeleteProfileButton.UseVisualStyleBackColor = true;
        DeleteProfileButton.Click += DeleteProfileButton_Click;
        // 
        // RenameProfileButton
        // 
        RenameProfileButton.Location = new System.Drawing.Point(30, 304);
        RenameProfileButton.Name = "RenameProfileButton";
        RenameProfileButton.Size = new System.Drawing.Size(104, 32);
        RenameProfileButton.TabIndex = 17;
        RenameProfileButton.Text = "Rename Profile";
        RenameProfileButton.UseVisualStyleBackColor = true;
        RenameProfileButton.Click += RenameProfileButton_Click;
        // 
        // ProgramNameTextBox
        // 
        ProgramNameTextBox.Location = new System.Drawing.Point(266, 42);
        ProgramNameTextBox.Name = "ProgramNameTextBox";
        ProgramNameTextBox.Size = new System.Drawing.Size(159, 23);
        ProgramNameTextBox.TabIndex = 18;
        ProgramNameTextBox.Text = "Program Name";
        // 
        // ProgramPathTextBox
        // 
        ProgramPathTextBox.Location = new System.Drawing.Point(266, 71);
        ProgramPathTextBox.Name = "ProgramPathTextBox";
        ProgramPathTextBox.Size = new System.Drawing.Size(159, 23);
        ProgramPathTextBox.TabIndex = 19;
        ProgramPathTextBox.Text = "/path/";
        // 
        // AddProgramLabel
        // 
        AddProgramLabel.Location = new System.Drawing.Point(266, 12);
        AddProgramLabel.Name = "AddProgramLabel";
        AddProgramLabel.Size = new System.Drawing.Size(159, 27);
        AddProgramLabel.TabIndex = 20;
        AddProgramLabel.Text = "Add Program";
        // 
        // BrowseButton
        // 
        BrowseButton.Location = new System.Drawing.Point(431, 70);
        BrowseButton.Name = "BrowseButton";
        BrowseButton.Size = new System.Drawing.Size(81, 23);
        BrowseButton.TabIndex = 21;
        BrowseButton.Text = "Browse...";
        BrowseButton.UseVisualStyleBackColor = true;
        BrowseButton.Click += BrowseButton_Click;
        // 
        // RemoveProgramButton
        // 
        RemoveProgramButton.BackColor = System.Drawing.Color.Red;
        RemoveProgramButton.Location = new System.Drawing.Point(266, 156);
        RemoveProgramButton.Name = "RemoveProgramButton";
        RemoveProgramButton.Size = new System.Drawing.Size(110, 30);
        RemoveProgramButton.TabIndex = 22;
        RemoveProgramButton.Text = "Remove Program";
        RemoveProgramButton.UseVisualStyleBackColor = false;
        RemoveProgramButton.Click += RemoveProgramButton_Click;
        // 
        // SaveButton
        // 
        SaveButton.Location = new System.Drawing.Point(50, 376);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new System.Drawing.Size(147, 40);
        SaveButton.TabIndex = 23;
        SaveButton.Text = "Save";
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // CancelButton
        // 
        CancelButton.Location = new System.Drawing.Point(302, 376);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new System.Drawing.Size(147, 40);
        CancelButton.TabIndex = 24;
        CancelButton.Text = "Cancel";
        CancelButton.UseVisualStyleBackColor = true;
        // 
        // ProfileNameTextBox
        // 
        ProfileNameTextBox.Location = new System.Drawing.Point(29, 237);
        ProfileNameTextBox.Name = "ProfileNameTextBox";
        ProfileNameTextBox.Size = new System.Drawing.Size(197, 23);
        ProfileNameTextBox.TabIndex = 25;
        ProfileNameTextBox.Text = "Profile name";
        // 
        // EnterProfileNameLabel
        // 
        EnterProfileNameLabel.Location = new System.Drawing.Point(29, 214);
        EnterProfileNameLabel.Name = "EnterProfileNameLabel";
        EnterProfileNameLabel.Size = new System.Drawing.Size(196, 23);
        EnterProfileNameLabel.TabIndex = 26;
        EnterProfileNameLabel.Text = "Enter profile name:";
        EnterProfileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ProfileEditorForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(537, 450);
        Controls.Add(EnterProfileNameLabel);
        Controls.Add(ProfileNameTextBox);
        Controls.Add(ProfilesComboBox);
        Controls.Add(CancelButton);
        Controls.Add(SaveButton);
        Controls.Add(RemoveProgramButton);
        Controls.Add(BrowseButton);
        Controls.Add(AddProgramLabel);
        Controls.Add(ProgramPathTextBox);
        Controls.Add(ProgramNameTextBox);
        Controls.Add(RenameProfileButton);
        Controls.Add(DeleteProfileButton);
        Controls.Add(AddProfileButton);
        Controls.Add(ProgramsListBox);
        Controls.Add(SelectProfileLabel);
        Controls.Add(label1);
        Controls.Add(AddProgramButton);
        Location = new System.Drawing.Point(15, 15);
        Text = "Edit Profile";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox ProfileNameTextBox;
    private System.Windows.Forms.Label EnterProfileNameLabel;

    private System.Windows.Forms.Button SaveButton;

    private System.Windows.Forms.Button CancelButton;

    private System.Windows.Forms.Button AddProgramButton;

    private System.Windows.Forms.Button RenameProfileButton;
    private System.Windows.Forms.TextBox ProgramNameTextBox;
    private System.Windows.Forms.TextBox ProgramPathTextBox;
    private System.Windows.Forms.Label AddProgramLabel;
    private System.Windows.Forms.Button BrowseButton;

    private System.Windows.Forms.Button AddProfileButton;
    private System.Windows.Forms.Button DeleteProfileButton;

    private System.Windows.Forms.ListBox ProgramsListBox;

    private System.Windows.Forms.Label SelectProfileLabel;

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.ComboBox ProfilesComboBox;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button RemoveProgramButton;

    #endregion
}