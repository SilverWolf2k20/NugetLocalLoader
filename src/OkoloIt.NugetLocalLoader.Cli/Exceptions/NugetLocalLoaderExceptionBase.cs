namespace OkoloIt.NugetLocalLoader.Cli.Exceptions;

/// <summary>
/// Base NugetLocalLoader exception.
/// </summary>
/// <param name="message">Exception message.</param>
internal abstract class NugetLocalLoaderExceptionBase(string message)
    : Exception(message)
{
}
