using System.CommandLine;
using System.CommandLine.Invocation;

using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Core;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Load.Subcommands;

[CliCommand(
    Name = "package",
    Description = "Displays a list of versions for this package.",
    Parent = typeof(LoadCommand))]
public sealed class LoadPackageSubcommand
{
    #region Public Properties

    [CliOption(Description = "Target version.")]
    public string Version { get; set; } = string.Empty;

    [CliOption(Description = "Target path.")]
    public string Path { get; set; } = string.Empty;

    [CliArgument(Description = "Target package name.")]
    public string PackageName { get; set; } = string.Empty;

    #endregion Public Properties

    #region Public Methods

    public async Task RunAsync(InvocationContext context)
    {
        if (string.IsNullOrWhiteSpace(Version))
            Version = await GetLatestVesionAsync(
                PackageName,
                context.GetCancellationToken());

        context.Console.WriteLine($"Select version: {Version}");

        if (string.IsNullOrWhiteSpace(Path))
            Path = GetDefaultPath();

        context.Console.WriteLine($"Loading...");

        PackageLoader packageLoader = new();
        string filePath = await packageLoader.LoadPackageAsync(
            PackageName,
            Version,
            Path,
            context.GetCancellationToken());

        context.Console.WriteLine($"Downloaded to:  {filePath}");
    }

    #endregion Public Methods

    #region Private Methods

    private static string GetDefaultPath()
    {
        string profilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        return System.IO.Path.Combine(profilePath, "Downloads");
    }

    private static async Task<string> GetLatestVesionAsync(
        string packageName,
        CancellationToken cancellationToken)
    {
        PackageHelper packageHelper = new();
        IEnumerable<string> versions = await packageHelper.GetAllPackageVersionsAsync(
            packageName,
            count: 1,
            cancellationToken);

        return versions.First();
    }

    #endregion Private Methods
}
