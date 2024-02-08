using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Cli.Commands;
using OkoloIt.NugetLocalLoader.Cli.Exceptions;
using OkoloIt.NugetLocalLoader.Cli.Helpers;

using Pastel;

using System.Reflection;

[assembly: AssemblyVersion("1.1.0.*")]

try {
    await Cli.RunAsync<RootCliCommand>(args);
}
catch (OperationCanceledException) {
    Console.WriteLine("The command was canceled.".Pastel(CliColors.Warning));
}
catch (NugetLocalLoaderExceptionBase ex) {
    Console.Error.WriteLine(ex.Message.Pastel(CliColors.Error));
}
catch (Exception ex) {
    Console.Error.WriteLine("Unregistered exception.".Pastel(CliColors.Error));
    Console.Error.WriteLine(ex.ToString().Pastel(CliColors.Error));
}
