using System.CommandLine;
using System.CommandLine.Invocation;

using DotMake.CommandLine;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Find;

[CliCommand(
    Name = "find",
    Description = "Performs a search.",
    Parent = typeof(RootCliCommand))]
public sealed class FindCommand
{
    #region Public Methods

    public void Run(InvocationContext context)
    {
        context.Console.WriteLine("Enter the name of the subcommand or call help (-h; --help).");
    }

    #endregion Public Methods
}
