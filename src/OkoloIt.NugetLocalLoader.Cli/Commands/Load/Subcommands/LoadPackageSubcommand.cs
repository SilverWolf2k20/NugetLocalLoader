using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text.RegularExpressions;

using DotMake.CommandLine;

using NuGet.Packaging.Core;
using NuGet.Versioning;

using OkoloIt.NugetLocalLoader.Core;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Load.Subcommands;

[CliCommand(
    Name = "package",
    Description = "Displays a list of versions for this package.",
    Parent = typeof(LoadCommand))]
public sealed partial class LoadPackageSubcommand
{
    #region Public Properties

    [CliOption(
        Description = "Dependency loading flag.",
        Arity = CliArgumentArity.Zero)]
    public bool CanLoadDependencies { get; set; } = false;

    [CliOption(
        Description = "Flag to ignore existing packets.",
        Aliases = ["-i"],
        Arity = CliArgumentArity.Zero)]
    public bool CanIgnoreExisting { get; set; } = false;

    [CliOption(Description = "Target version.")]
    public string Version { get; set; } = string.Empty;

    [CliOption(Description = "Directory where packages are stored.")]
    public string PackageFolder { get; set; } = string.Empty;

    [CliOption(Description = "Path to the file with the list of existing packages.")]
    public string ExistingPackageList { get; set; } = string.Empty;

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
            PackageFolder,
            cancellationToken);

        if (CanLoadDependencies == false) {
            context.Console.WriteLine($"Downloaded package to:  {filePath}");
            return;
        }

        IList<PackageIdentity> dependencies = await GetDependencies(cancellationToken);

        if (CanIgnoreExisting) {
            IEnumerable<PackageIdentity> existingPackages = await GetListOfExistingPackages(cancellationToken);
            dependencies = dependencies.Except(existingPackages).ToList();
        }

        for (var i = 0; i < dependencies.Count; ++i) {
            if (cancellationToken.IsCancellationRequested)
                break;

            PackageIdentity dependence = dependencies[i];
            context.Console.WriteLine($"Load ({i + 1}/{dependencies.Count}):  {dependence.Id} [{dependence.Version}]");

            _ = await packageLoader.LoadPackageAsync(
                dependence.Id,
                dependence.Version,
                PackageFolder,
                cancellationToken);
        }

        context.Console.WriteLine($"Downloaded packages to:  {PackageFolder}");
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
        if (string.IsNullOrWhiteSpace(PackageFolder) == false)
            return;

        string profilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        PackageFolder = Path.Combine(profilePath, "Downloads");
    }

    private async Task<IEnumerable<PackageIdentity>> GetListOfExistingPackages(
        CancellationToken cancellationToken)
    {
        string[] paths;

        if (    string.IsNullOrWhiteSpace(ExistingPackageList)
             || File.Exists(ExistingPackageList) == false)
            paths = Directory.GetFiles(PackageFolder, "*.nupkg");
        else
            paths = await File.ReadAllLinesAsync(ExistingPackageList, cancellationToken);

        List<PackageIdentity> existingPackages = new(paths.Length);

        foreach (string path in paths) {
            string packageFullName = Path.GetFileNameWithoutExtension(path);

            string packageName    = GeneratePackageNameRegex().Match(packageFullName).Groups[1].Value;
            string packageVersion = packageFullName[(packageName.Length + 1)..];

            existingPackages.Add(new PackageIdentity(packageName, new NuGetVersion(packageVersion)));
        }

        return existingPackages;
    }

    [GeneratedRegex(@"(\D+)[.]")]
    private static partial Regex GeneratePackageNameRegex();

    #endregion Private Methods
}
