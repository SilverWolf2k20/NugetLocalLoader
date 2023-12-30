using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace OkoloIt.NugetLocalLoader.Core;

/// <summary>
/// Nuget package helper.
/// </summary>
public sealed class PackageHelper
{
    #region Private Fields

    private readonly SourceCacheContext _cache;
    private readonly CancellationToken _cancellationToken;
    private readonly ILogger _logger;
    private readonly SourceRepository _repository;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Creates an instance of the nuget package helper.
    /// </summary>
    public PackageHelper()
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
    public async Task<IEnumerable<string>> GetAllPackageVersionsAsync(string packageName, int count)
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

    /// <summary>
    /// Returns a list of all packages.
    /// </summary>
    /// <param name="packageName">Package name.</param>
    /// <param name="count">Number of output packets matching by name.</param>
    /// <returns>List of packages.</returns>
    public async Task<IEnumerable<string>> GetPackagesAsync(string packageName, int count)
    {
        PackageSearchResource resource = await _repository.GetResourceAsync<PackageSearchResource>();
        SearchFilter searchFilter = new(includePrerelease: true);

        IEnumerable<IPackageSearchMetadata> results = await resource.SearchAsync(
            packageName,
            searchFilter,
            skip: 0,
            take: count,
            _logger,
            _cancellationToken);

        return results.Select(p => p.Identity.Id.ToString());
    }

    #endregion Public Methods
}