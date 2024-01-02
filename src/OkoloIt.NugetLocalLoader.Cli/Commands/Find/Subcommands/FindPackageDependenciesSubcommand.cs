using System.CommandLine;
using System.CommandLine.Invocation;

using DotMake.CommandLine;

using NuGet.Packaging.Core;

using OkoloIt.NugetLocalLoader.Core;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Find.Subcommands;

[CliCommand(
    Name = "deps",
    Description = "Displays a list of dependencies for this package.",
    Parent = typeof(FindCommand))]
public sealed class FindPackageDependenciesSubcommand
{
    #region Public Properties

    [CliOption(Description = "Target version.")]
    public string Version { get; set; } = string.Empty;

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

        PackageHelper packageManager = new();
        IEnumerable<PackageIdentity> dependencies = await packageManager.GetAllPackageDependenciesAsync(
            PackageName,
            Version,
            context.GetCancellationToken());

        foreach (PackageIdentity dependence in dependencies)
            context.Console.WriteLine($"{dependence.Id} [{dependence.Version}]");
    }

    #endregion Public Methods

    #region Private Methods

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
