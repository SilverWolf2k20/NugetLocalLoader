using NuGet.Common;
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
    public PackageLoader() : this(NullLogger.Instance)
    {
    }

    /// <summary>
    /// Creates an instance of the nuget package loader.
    /// </summary>
    /// <param name="logger">Logger instance.</param>
    public PackageLoader(ILogger logger)
    {
        _logger = logger;
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
        return await LoadPackageAsync(packageName, packageVersion, path, cancellationToken);
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

        // Получение метаданных пакета.
        PackageMetadataResource resource = await _repository.GetResourceAsync<PackageMetadataResource>();
        IEnumerable<IPackageSearchMetadata> packages = await resource.GetMetadataAsync(
            "Avalonia",
            includePrerelease: true,
            includeUnlisted: false,
            _cache,
            _logger,
            cancellationToken);

        IPackageSearchMetadata? package = packages.FirstOrDefault(p => p.Identity.Version.Equals(packageVersion));

        if (package is null)
            return "Не удалось скачать пакет.";

        string filePath = Path.Combine(path, $"{package.Identity.Id}.{package.Identity.Version}.nupkg").ToLower();
        using var packageStream = File.OpenWrite(filePath);

        FindPackageByIdResource findPackageByIdResource = await _repository.GetResourceAsync<FindPackageByIdResource>();
        await findPackageByIdResource.CopyNupkgToStreamAsync(
            package.Identity.Id,
            package.Identity.Version,
            packageStream,
            _cache,
            _logger,
            cancellationToken);

        return filePath;
    }

    #endregion Public Methods
}
