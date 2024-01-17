namespace OkoloIt.NugetLocalLoader.Cli.Exceptions;

/// <summary>
/// Exception that occurs when using a command without necessarily specifying a subcommand.
/// </summary>
/// <param name="message">Exception message.</param>
internal sealed class NotMandatoryCommandException(string message) 
    : NugetLocalLoaderExceptionBase(message)
{
}
