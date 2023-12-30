using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Core;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Find.Subcommands;

[CliCommand(
    Name = "versions",
    Description = "Displays a list of versions for this package.",
    Parent = typeof(FindCommand))]
public sealed class FindPackageVersionsSubcommand
{
    #region Public Properties

    [CliOption(Description = "Number of output records from the latest version.")]
    public int Count { get; set; } = 10;

    [CliArgument(Description = "Target package name.")]
    public string PackageName { get; set; } = string.Empty;

    #endregion Public Properties

    #region Public Methods

    public async Task RunAsync()
    {
        PackageHelper packageManager = new();
        IEnumerable<string> versions = await packageManager.GetAllPackageVersionsAsync(PackageName, Count);

        foreach (string version in versions)
            Console.WriteLine(version);
    }

    #endregion Public Methods
}
