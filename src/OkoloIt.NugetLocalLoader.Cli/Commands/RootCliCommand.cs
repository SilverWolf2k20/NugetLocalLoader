using DotMake.CommandLine;

namespace OkoloIt.NugetLocalLoader.Cli.Commands;

[CliCommand(Description = "A root cli command")]
public class RootCliCommand
{
    #region Public Methods

    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($@"<Okolo IT>");

        Console.ResetColor();
        Console.WriteLine($@"Hello, this is a NugetLocalLoader!");
    }

    #endregion Public Methods
}
