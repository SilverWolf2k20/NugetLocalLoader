using System.CommandLine.Invocation;

using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Cli.Exceptions;

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
        throw new NotMandatoryCommandException("The mandatory command is not specified.");
    }

    #endregion Public Methods
}
