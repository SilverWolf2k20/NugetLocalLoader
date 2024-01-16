using System.CommandLine;
using System.CommandLine.Invocation;
using System.Drawing;

using DotMake.CommandLine;

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
            """.Pastel(Color.FromArgb(0, 72, 128)));
        context.Console.WriteLine("\nHello, this is a NugetLocalLoader!");
        context.Console.WriteLine("URL: https://github.com/SilverWolf2k20/NugetLocalLoader");
    }

    #endregion Public Methods
}
