using System.CommandLine;
using System.CommandLine.Invocation;

using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Cli.Helpers;

using Pastel;

namespace OkoloIt.NugetLocalLoader.Cli.Commands;

[CliCommand(Description = "A root cli command.")]
public class RootCliCommand
{
    #region Public Methods

    public void Run(InvocationContext context)
    {
        context.Console.WriteLine($"Developed <Okolo IT>");
        context.Console.WriteLine("""
             _     _     _   _ _   _  ____ _____ _____ 
            | |   | |   | \ | | | | |/ ___| ____|_   _|
            | |   | |   |  \| | | | | |  _|  _|   | |
            | |___| |___| |\  | |_| | |_| | |___  | |
            |_____|_____|_| \_|\___/ \____|_____| |_|
            """.Pastel(CliColors.Information));
        context.Console.WriteLine("\nHello, this is a NugetLocalLoader!");
        context.Console.WriteLine("URL: https://github.com/SilverWolf2k20/NugetLocalLoader");
    }

    #endregion Public Methods
}
