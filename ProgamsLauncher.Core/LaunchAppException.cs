namespace ProgramsLauncher.Core;

public class LaunchAppException : Exception
{
    private readonly AppEntry _app;

    public LaunchAppException(AppEntry app)
    {
        _app = app;
    }
    
    public override string Message => $"Failed to launch application: {_app.Name} at path: {_app.Path}";
}