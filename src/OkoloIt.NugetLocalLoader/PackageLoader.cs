using System;

using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace OkoloIt.NugetLocalLoader.Core;

/// <summary>
/// Nuget package loader.
/// </summary>
public sealed class PackageLoader
{
    #region Private Fields

    private readonly SourceCacheContext _cache;
    private readonly ILogger _logger;
    private readonly SourceRepository _repository;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Creates an instance of the nuget package loader.
    /// </summary>
    public PackageLoader()
    {
        _logger = NullLogger.Instance;
        _cache = new SourceCacheContext();
        _repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Downloads the specified version of the package to the folder.
    /// </summary>
    /// <param name="packageName">Target package name.</param>
    /// <param name="version">Target version.</param>
    /// <param name="path">Target path.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Represents an asynchronous operation.</returns>
    public async Task<string> LoadPackageAsync(
        string packageName,
        string version,
        string path,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(version, nameof(version));

        NuGetVersion packageVersion = new(version);
        return await LoadPackageAsync(packageName , packageVersion, path, cancellationToken);
    }

    /// <summary>
    /// Downloads the specified version of the package to the folder.
    /// </summary>
    /// <param name="packageName">Target package name.</param>
    /// <param name="packageVersion">Target version.</param>
    /// <param name="path">Target path.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>Represents an asynchronous operation.</returns>
    public async Task<string> LoadPackageAsync(
        string packageName,
        NuGetVersion packageVersion,
        string path,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(packageName, nameof(packageName));

        if (Directory.Exists(path) == false)
            throw new DirectoryNotFoundException($"There is no directory found at path {path}.");

        FindPackageByIdResource resource = await _repository.GetResourceAsync<FindPackageByIdResource>();

        using MemoryStream packageStream = new();

        await resource.CopyNupkgToStreamAsync(
            packageName,
            packageVersion,
            packageStream,
            _cache,
            _logger,
            cancellationToken);

        using PackageArchiveReader packageReader = new(packageStream);
        NuspecReader nuspecReader = await packageReader.GetNuspecReaderAsync(cancellationToken);

        string filePath = Path.Combine(path, $"{packageName}.{packageVersion}.nupkg");

        packageStream.CopyToFile(Path.Combine(path, filePath));

        return filePath;
    }

    #endregion Public Methods
}
