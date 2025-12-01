using ProgramsLauncher.Core;

namespace ProgramsLauncher;

public class ProfileEditorFormFactory : IProfileEditorFormFactory
{
    private readonly IProfilesEditorModel _editorModel;

    public ProfileEditorFormFactory(IProfilesEditorModel editorModel)
    {
        _editorModel = editorModel;
    }

    public ProfileEditorForm Create()
    {
        return new ProfileEditorForm(_editorModel);
    }
}