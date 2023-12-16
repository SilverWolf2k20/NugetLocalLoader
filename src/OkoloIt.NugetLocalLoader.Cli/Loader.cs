using CommandDotNet;

using OkoloIt.NugetLocalLoader.Core;

namespace OkoloIt.NugetLocalLoader.Cli;

public sealed class Loader
{
    #region Public Methods

    [Command(
        "package",
        Description = "Downloads the package.",
        Usage = "package <package_name>")]
    public void LoadPackage(
        IConsole console,
        [Operand("packageName", Description = "Target package name.")]
        string packageName,
        [Named('v', Description = "Target version.")]
        string version = "",
        [Named('p', Description = "Target path.")]
        string path = "")
    {
        if (string.IsNullOrWhiteSpace(version))
            version = GetLatestVesion(packageName);

        console.WriteLine($"Select version: {version}.");

        if (string.IsNullOrWhiteSpace(path))
            path = GetDefaultPath();

        new PackageLoader().LoadPackage(packageName, version, path).Wait();

        console.WriteLine($"Downloaded to:  {path}.");
    }

    #endregion Public Methods

    #region Private Methods

    private static string GetDefaultPath()
    {
        string profilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        return Path.Combine(profilePath, "Downloads");
    }

    private static string GetLatestVesion(string packageName)
    {
        return new PackageHelper().GetAllPackageVersions(packageName, 1).Result
            .First();
    }

    #endregion Private Methods
}