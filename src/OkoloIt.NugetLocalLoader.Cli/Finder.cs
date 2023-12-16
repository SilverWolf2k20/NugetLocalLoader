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
        PackageManager packageManager = new PackageManager();
        IEnumerable<string> versions = packageManager.GetAllPackageVersions(packageName, count).Result;

        foreach (string version in versions)
            console.WriteLine(version);
    }

    #endregion Public Methods
}