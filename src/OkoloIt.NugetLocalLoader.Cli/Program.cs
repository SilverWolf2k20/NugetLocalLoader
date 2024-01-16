using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Cli.Commands;

using Pastel;

using System.Drawing;
using System.Reflection;

[assembly: AssemblyVersion("1.0.0.*")]

try {
    await Cli.RunAsync<RootCliCommand>(args);
}
catch (OperationCanceledException) {
    Console.WriteLine("The command was canceled.".Pastel(Color.FromArgb(241, 210, 46)));
}
catch (Exception ex) {
    Console.Error.WriteLine("Unregistered exception.".Pastel(Color.FromArgb(158, 45, 34)));
    Console.Error.WriteLine(ex.ToString().Pastel(Color.FromArgb(158, 45, 34)));
}
