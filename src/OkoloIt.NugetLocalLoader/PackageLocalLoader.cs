using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace OkoloIt.NugetLocalLoader.Core;

/// <summary>
/// Nuget package manager.
/// </summary>
public sealed class PackageManager
{
    #region Private Fields

    private SourceCacheContext _cache;
    private CancellationToken _cancellationToken;
    private ILogger _logger;
    private SourceRepository   _repository;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Creates an instance of the nuget package manager.
    /// </summary>
    public PackageManager()
    {
        _logger = NullLogger.Instance;
        _cancellationToken = CancellationToken.None;
        _cache = new SourceCacheContext();
        _repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Returns a list of all versions of the package.
    /// </summary>
    /// <param name="packageName">Package name.</param>
    /// <param name="count">Number of output records from the latest version.</param>
    /// <returns>List of all versions of the package.</returns>
    public async Task<IEnumerable<string>> GetAllPackageVersions(string packageName, int count)
    {
        FindPackageByIdResource resource = await _repository.GetResourceAsync<FindPackageByIdResource>();

        IEnumerable<NuGetVersion> versions = await resource.GetAllVersionsAsync(
            packageName,
            _cache,
            _logger,
            _cancellationToken);

        return versions.OrderByDescending(v => v.Version)
            .Take(count)
            .Select(version => version.ToString());
    }

    #endregion Public Methods
}