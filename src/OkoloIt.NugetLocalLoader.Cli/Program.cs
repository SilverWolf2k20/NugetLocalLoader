using CommandDotNet;

namespace OkoloIt.NugetLocalLoader.Cli;

[Command(
    Description = "NugetLocalLoader is a program to load Nuget packages into a local folder with all dependencies.")]
public class Program
{
    #region Public Properties

    [Subcommand(RenameAs = "find")]
    public Finder Finder { get; set; } = new();

    [Subcommand(RenameAs = "load")]
    public Loader Loader { get; set; } = new();

    #endregion Public Properties

    #region Public Methods

    public static async Task<int> Main(string[] args)
    {
        return await new AppRunner<Program>()
            .UseVersionMiddleware()
            .RunAsync(args);
    }

    #endregion Public Methods
}
