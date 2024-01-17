namespace OkoloIt.NugetLocalLoader.Cli.Exceptions;

/// <summary>
/// Exception that occurs if no package was found.
/// </summary>
/// <param name="packageName">Package name.</param>
internal class PackageNotFoundException(string packageName) 
    : NugetLocalLoaderExceptionBase($"{packageName} not found!")
{
}
