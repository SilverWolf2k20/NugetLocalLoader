using CommandDotNet;

using OkoloIt.NugetLocalLoader.Core;

[Command(
    Description = "NugetLocalLoader is a program to load Nuget packages into a local folder with all dependencies.")]
public class Program
{
    public static async Task<int> Main(string[] args)
    {
        return await new AppRunner<Program>()
            .UseVersionMiddleware()
            .RunAsync(args);
    }

    [Subcommand(RenameAs ="find")]
    public Finder Finder { get; set; } = new();
}

public class Finder
{
    [Command("versions")]
    public void FindVersions(IConsole console, string packageName)
    {
        PackageManager packageManager = new PackageManager();
        IEnumerable<string> versions = packageManager.GetAllPackageVersions(packageName).Result;

        foreach (string version in versions)
            console.WriteLine(version);
    }
}