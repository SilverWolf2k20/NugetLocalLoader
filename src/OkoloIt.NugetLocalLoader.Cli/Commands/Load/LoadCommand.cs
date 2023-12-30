using DotMake.CommandLine;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Load;

[CliCommand(
    Name = "load",
    Description = "Loads packages.",
    Parent = typeof(RootCliCommand))]
public sealed class LoadCommand
{
    #region Public Methods

    public void Run()
    {
        Console.WriteLine("Enter the name of the subcommand or call help (-h; --help).");
    }

    #endregion Public Methods
}
