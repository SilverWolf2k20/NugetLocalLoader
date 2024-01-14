using System.CommandLine;
using System.CommandLine.Invocation;

using DotMake.CommandLine;

namespace OkoloIt.NugetLocalLoader.Cli.Commands;

[CliCommand(Description = "A root cli command.")]
public class RootCliCommand
{
    #region Public Methods

    public void Run(InvocationContext context)
    {
        context.Console.WriteLine("<Okolo IT>\n");
        context.Console.WriteLine("""
            ╔╗  ╔╗    ╔═╦╗ ╔╗╔╗ ╔══╗ ╔══╗ ╔══╗
            ║║  ║║    ║║║║ ║║║║ ║╔═╣ ║ ═╣ ╚╗╔╝
            ║╚╗ ║╚╗   ║║║║ ║╚╝║ ║╚╗║ ║ ═╣  ║║
            ╚═╝ ╚═╝   ╚╩═╝ ╚══╝ ╚══╝ ╚══╝  ╚╝
            """);
        context.Console.WriteLine("\nHello, this is a NugetLocalLoader!\n");
    }

    #endregion Public Methods
}
