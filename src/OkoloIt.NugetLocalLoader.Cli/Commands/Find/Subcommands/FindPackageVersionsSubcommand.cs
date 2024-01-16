using System.CommandLine;
using System.CommandLine.Invocation;

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
    public required string PackageName { get; set; }

    #endregion Public Properties

    #region Public Methods

    public async Task RunAsync(InvocationContext context)
    {
        PackageHelper packageManager = new();

        context.Console.WriteLine($"Loading...");

        IEnumerable<string> versions = await packageManager.GetAllPackageVersionsAsync(
            PackageName,
            Count,
            context.GetCancellationToken());

        foreach (string version in versions)
            context.Console.WriteLine(version);
    }

    #endregion Public Methods
}
