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

    #endregion Public Properties

    #region Public Methods

    public async Task RunAsync(InvocationContext context)
    {
        await Task.CompletedTask;

        if (Directory.Exists(PackageFolder) == false)
            context.Console.WriteLine("Directory not found.");

        string[] files = Directory.GetFiles(PackageFolder);

        if (string.IsNullOrWhiteSpace(SaveToFile) == false) {
            File.WriteAllLines(SaveToFile, files);
            context.Console.WriteLine($"Saved in: {SaveToFile}");
            return;
        }

        foreach (string file in files) {
            if (context.GetCancellationToken().IsCancellationRequested)
                break;

            context.Console.WriteLine(file);
        }
    }

    #endregion Public Methods
}
