using System.CommandLine.Invocation;

using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Cli.Exceptions;

namespace OkoloIt.NugetLocalLoader.Cli.Commands.Load;

[CliCommand(
    Name = "load",
    Description = "Loads packages.",
    Parent = typeof(RootCliCommand))]
public sealed class LoadCommand
{
    #region Public Methods

    public void Run(InvocationContext context)
    {
        throw new NotMandatoryCommandException("The mandatory command is not specified.");
    }

    #endregion Public Methods
}
