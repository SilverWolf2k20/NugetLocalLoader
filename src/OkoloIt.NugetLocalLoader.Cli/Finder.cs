using CommandDotNet;

using OkoloIt.NugetLocalLoader.Core;

namespace OkoloIt.NugetLocalLoader.Cli;

public sealed class Finder
{
    #region Public Methods

    [Command(
        "versions",
        Description = "Displays a list of versions for this package.",
        Usage = "versions <package_name>")]
    public void FindVersions(
        IConsole console,
        [Operand("packageName", Description = "Target package name.")]
        string packageName,
        [Named('c', Description = "Number of output records from the latest version.")]
        int count = 10)
    {
        PackageHelper packageManager = new PackageHelper();
        IEnumerable<string> versions = packageManager.GetAllPackageVersions(packageName, count).Result;

        foreach (string version in versions)
            console.WriteLine(version);
    }

    [Command(
        "packages",
        Description = "Displays a list of packages.",
        Usage = "packages <package_name>")]
    public void FindPackages(IConsole console,
        [Operand("packageName", Description = "Target package name.")]
        string packageName,
        [Named('c', Description = "Number of output records.")]
        int count = 10)
    {
        PackageHelper packageManager = new PackageHelper();
        IEnumerable<string> versions = packageManager.GetPackages(packageName, count).Result;

        foreach (string version in versions)
            console.WriteLine(version);
    }

    #endregion Public Methods
}