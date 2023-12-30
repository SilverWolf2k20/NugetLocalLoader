using DotMake.CommandLine;

using OkoloIt.NugetLocalLoader.Cli.Commands;

using System.Reflection;

[assembly: AssemblyVersion("0.0.3.*")]

await Cli.RunAsync<RootCliCommand>(args);
