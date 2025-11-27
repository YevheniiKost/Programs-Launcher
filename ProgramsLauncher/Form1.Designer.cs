using System.ComponentModel;

namespace ProgramsLauncher;

partial class Form1
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
        RunAllButton = new System.Windows.Forms.Button();
        ProfilesComboBox = new System.Windows.Forms.ComboBox();
        SelectProfileLabel = new System.Windows.Forms.Label();
        ProgramsListBox = new System.Windows.Forms.ListBox();
        EditProfilesButton = new System.Windows.Forms.Button();
        AutostartCheckBox = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        // 
        // RunAllButton
        // 
        RunAllButton.BackColor = System.Drawing.Color.Yellow;
        RunAllButton.Location = new System.Drawing.Point(21, 31);
        RunAllButton.Name = "RunAllButton";
        RunAllButton.Size = new System.Drawing.Size(190, 65);
        RunAllButton.TabIndex = 0;
        RunAllButton.Text = "Run All";
        RunAllButton.UseVisualStyleBackColor = false;
        RunAllButton.Click += RunAllButton_Click;
        // 
        // ProfilesComboBox
        // 
        ProfilesComboBox.FormattingEnabled = true;
        ProfilesComboBox.Location = new System.Drawing.Point(21, 128);
        ProfilesComboBox.Name = "ProfilesComboBox";
        ProfilesComboBox.Size = new System.Drawing.Size(189, 23);
        ProfilesComboBox.TabIndex = 1;
        ProfilesComboBox.SelectedIndexChanged += ProfilesComboBox_SelectedIndexChanged;
        // 
        // SelectProfileLabel
        // 
        SelectProfileLabel.Location = new System.Drawing.Point(21, 102);
        SelectProfileLabel.Name = "SelectProfileLabel";
        SelectProfileLabel.Size = new System.Drawing.Size(190, 23);
        SelectProfileLabel.TabIndex = 2;
        SelectProfileLabel.Text = "Select profile:";
        SelectProfileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ProgramsListBox
        // 
        ProgramsListBox.FormattingEnabled = true;
        ProgramsListBox.ItemHeight = 15;
        ProgramsListBox.Location = new System.Drawing.Point(21, 176);
        ProgramsListBox.Name = "ProgramsListBox";
        ProgramsListBox.Size = new System.Drawing.Size(190, 79);
        ProgramsListBox.TabIndex = 3;
        // 
        // EditProfilesButton
        // 
        EditProfilesButton.Location = new System.Drawing.Point(46, 304);
        EditProfilesButton.Name = "EditProfilesButton";
        EditProfilesButton.Size = new System.Drawing.Size(131, 30);
        EditProfilesButton.TabIndex = 4;
        EditProfilesButton.Text = "Edit Profiles";
        EditProfilesButton.UseVisualStyleBackColor = true;
        EditProfilesButton.Click += EditProfilesButton_Click;
        // 
        // AutostartCheckBox
        // 
        AutostartCheckBox.Location = new System.Drawing.Point(21, 267);
        AutostartCheckBox.Name = "AutostartCheckBox";
        AutostartCheckBox.Size = new System.Drawing.Size(188, 24);
        AutostartCheckBox.TabIndex = 5;
        AutostartCheckBox.Text = "Run on Windows startup";
        AutostartCheckBox.UseVisualStyleBackColor = true;
        AutostartCheckBox.CheckedChanged += AutostartCheckBox_CheckedChanged;
        // 
        // Programs Launcher
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(240, 362);
        Controls.Add(AutostartCheckBox);
        Controls.Add(EditProfilesButton);
        Controls.Add(ProgramsListBox);
        Controls.Add(SelectProfileLabel);
        Controls.Add(ProfilesComboBox);
        Controls.Add(RunAllButton);
        Name = "Programs Launcher";
        Text = "Programs Launcher";
        ResumeLayout(false);
    }

    private System.Windows.Forms.CheckBox AutostartCheckBox;

    private System.Windows.Forms.ListBox ProgramsListBox;
    private System.Windows.Forms.Button EditProfilesButton;

    private System.Windows.Forms.Button RunAllButton;
    private System.Windows.Forms.ComboBox ProfilesComboBox;
    private System.Windows.Forms.Label SelectProfileLabel;

    #endregion
}