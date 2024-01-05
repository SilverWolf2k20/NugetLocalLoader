using System.CommandLine;
using System.CommandLine.Invocation;

using DotMake.CommandLine;

using NuGet.Packaging.Core;

using OkoloIt.NugetLocalLoader.Core;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Load.Subcommands;

[CliCommand(
    Name = "package",
    Description = "Displays a list of versions for this package.",
    Parent = typeof(LoadCommand))]
public sealed class LoadPackageSubcommand
{
    #region Public Properties

    [CliOption(
        Description = "Dependency loading flag.",
        Arity = CliArgumentArity.Zero)]
    public bool CanLoadDependencies { get; set; } = false;

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
        CancellationToken cancellationToken = context.GetCancellationToken();

        await ConfiguteVersion(cancellationToken);
        ConfigutePath();

        context.Console.WriteLine($"Select version: {Version}");
        context.Console.WriteLine($"Loading {PackageName}");

        PackageLoader packageLoader = new();
        string filePath = await packageLoader.LoadPackageAsync(
            PackageName,
            Version,
            Path,
            cancellationToken);

        if (CanLoadDependencies == false) {
            context.Console.WriteLine($"Downloaded package to:  {filePath}");
            return;
        }

        IList<PackageIdentity> dependencies = await GetDependencies(cancellationToken);

        for (var i = 0; i < dependencies.Count; ++i) {
            if (cancellationToken.IsCancellationRequested)
                break;

            PackageIdentity dependence = dependencies[i];
            context.Console.WriteLine($"Load ({i + 1}/{dependencies.Count}):  {dependence.Id} [{dependence.Version}]");

            _ = await packageLoader.LoadPackageAsync(
                dependence.Id,
                dependence.Version,
                Path,
                cancellationToken);
        }

        context.Console.WriteLine($"Downloaded packages to:  {Path}");
    }

    #endregion Public Methods

    #region Private Methods

    private async Task<IList<PackageIdentity>> GetDependencies(CancellationToken cancellationToken)
    {
        PackageHelper packageManager = new();
        IEnumerable<PackageIdentity> dependencies = await packageManager.GetAllPackageDependenciesAsync(
            PackageName,
            Version,
            cancellationToken);

        return dependencies.ToList();
    }

    private async Task ConfiguteVersion(CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(Version) == false)
            return;

        PackageHelper packageHelper = new();
        IEnumerable<string> versions = await packageHelper.GetAllPackageVersionsAsync(
            PackageName,
            count: 1,
            cancellationToken);

        Version = versions.First();
    }

    private void ConfigutePath()
    {
        if (string.IsNullOrWhiteSpace(Path) == false)
            return;

        string profilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        Path = System.IO.Path.Combine(profilePath, "Downloads");
    }

    #endregion Private Methods
}
