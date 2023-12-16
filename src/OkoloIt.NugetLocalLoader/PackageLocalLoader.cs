using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace OkoloIt.NugetLocalLoader.Core;

public sealed class PackageManager
{
    #region Private Fields

    private SourceCacheContext _cache;
    private CancellationToken _cancellationToken;
    private ILogger _logger;
    private SourceRepository   _repository;

    #endregion Private Fields

    #region Public Constructors

    public PackageManager()
    {
        _logger = NullLogger.Instance;
        _cancellationToken = CancellationToken.None;
        _cache = new SourceCacheContext();
        _repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<IEnumerable<string>> GetAllPackageVersions(string packageName)
    {
        FindPackageByIdResource resource = await _repository.GetResourceAsync<FindPackageByIdResource>();

        IEnumerable<NuGetVersion> versions = await resource.GetAllVersionsAsync(
            packageName,
            _cache,
            _logger,
            _cancellationToken);

        return versions.OrderByDescending(v => v.Version)
            .Select(version => version.ToString());
    }

    #endregion Public Methods
}