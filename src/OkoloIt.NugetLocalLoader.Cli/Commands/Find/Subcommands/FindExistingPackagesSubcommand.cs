using System.CommandLine;
using System.CommandLine.Invocation;

using DotMake.CommandLine;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Find.Subcommands;

[CliCommand(
    Name = "storage",
    Description = "Displays a list of installed packages in the local folder.",
    Parent = typeof(FindCommand))]
public sealed class FindExistingPackagesSubcommand
{
    #region Public Properties

    [CliArgument(Description = "Directory where packages are stored.")]
    public string PackageFolder { get; set; } = string.Empty;

    [CliOption(Description = "Saves a list of installed packages to a file at the specified path.")]
    public string SaveToFile { get; set; } = string.Empty;

    [CliOption(Description = "Number of output records from the existing packages.")]
    public int Count { get; set; } = 10;

    #endregion Public Properties

    #region Public Methods

    public async Task RunAsync(InvocationContext context)
    {
        await Task.CompletedTask;

        if (Directory.Exists(PackageFolder) == false)
            context.Console.WriteLine("Directory not found.");

        string[] files = Directory.GetFiles(PackageFolder, "*.nupkg");

        if (string.IsNullOrWhiteSpace(SaveToFile) == false) {
            File.WriteAllLines(SaveToFile, files);
            context.Console.WriteLine($"Saved in: {SaveToFile}");
            return;
        }

        for (int i = 0; i < files.Length && i < Count; ++i) {
            if (context.GetCancellationToken().IsCancellationRequested)
                break;

            context.Console.WriteLine(files[i]);
        }
    }

    #endregion Public Methods
}
