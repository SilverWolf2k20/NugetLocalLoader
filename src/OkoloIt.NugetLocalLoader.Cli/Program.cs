using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Cli.Commands;

using System.Reflection;

[assembly: AssemblyVersion("1.0.0.*")]

try {
    await Cli.RunAsync<RootCliCommand>(args);
}
catch (OperationCanceledException) {
    Console.WriteLine("The command was canceled.");
}
catch (Exception ex) {
    Console.WriteLine("Unregistered exception.");
    Console.WriteLine(ex);
}
