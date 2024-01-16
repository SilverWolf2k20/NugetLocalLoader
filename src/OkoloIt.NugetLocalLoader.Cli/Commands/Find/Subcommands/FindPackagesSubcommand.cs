using System.CommandLine;
using System.CommandLine.Invocation;

using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Core;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Find.Subcommands;

[CliCommand(
    Name = "packages",
    Description = "Displays a list of packages.",
    Parent = typeof(FindCommand))]
public sealed class FindPackagesSubcommand
{
    #region Public Properties

    [CliOption(Description = "Number of output records.")]
    public int Count { get; set; } = 10;

    [CliArgument(Description = "Target package name.")]
    public required string PackageName { get; set; }

    #endregion Public Properties

    #region Public Methods

    public async Task RunAsync(InvocationContext context)
    {
        PackageHelper packageManager = new();

        context.Console.WriteLine($"Loading...");

        IEnumerable<string> packages = await packageManager.GetPackagesAsync(
            PackageName,
            Count,
            context.GetCancellationToken());

        foreach (string package in packages)
            context.Console.WriteLine(package);
    }

    #endregion Public Methods
}
