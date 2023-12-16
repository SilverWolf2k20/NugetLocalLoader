using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace OkoloIt.NugetLocalLoader.Core;

public sealed class PackageLoader
{
    #region Private Fields

    private SourceCacheContext _cache;
    private CancellationToken _cancellationToken;
    private ILogger _logger;
    private SourceRepository _repository;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Creates an instance of the nuget package loader.
    /// </summary>
    public PackageLoader()
    {
        _logger = NullLogger.Instance;
        _cancellationToken = CancellationToken.None;
        _cache = new SourceCacheContext();
        _repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task LoadPackage(string packageName, string version, string path)
    {
        FindPackageByIdResource resource = await _repository.GetResourceAsync<FindPackageByIdResource>();

        NuGetVersion packageVersion = new(version);
        using MemoryStream packageStream = new();

        await resource.CopyNupkgToStreamAsync(
            packageName,
            packageVersion,
            packageStream,
            _cache,
            _logger,
            _cancellationToken);

        using PackageArchiveReader packageReader = new(packageStream);
        NuspecReader nuspecReader = await packageReader.GetNuspecReaderAsync(_cancellationToken);

        packageStream.CopyToFile(Path.Combine(path, $"{packageName}.{version}.nupkg"));
    }

    #endregion Public Methods
}