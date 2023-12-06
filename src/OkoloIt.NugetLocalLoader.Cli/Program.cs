using CommandDotNet;

[Command(
    Description = "NugetLocalLoader is a program to load Nuget packages into a local folder with all dependencies.")]
public class Program
{
    public static async Task<int> Main(string[] args)
    {
        return await new AppRunner<Program>()
            .UseVersionMiddleware()
            .RunAsync(args);
    }

    [Subcommand(RenameAs ="find")]
    public Finder Finder { get; set; } = null!;
}

public class Finder
{
    [DefaultCommand]
    public static void FinderImpl(IConsole console) => console.WriteLine("find");
}

// https://commanddotnet.bilal-fazlani.com/gettingstarted/getting-started-300-help/