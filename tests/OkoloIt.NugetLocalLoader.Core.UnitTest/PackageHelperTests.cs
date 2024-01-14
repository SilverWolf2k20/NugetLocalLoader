using NuGet.Packaging.Core;

namespace OkoloIt.NugetLocalLoader.Core.UnitTest;

[TestFixture]
internal class PackageHelperTests
{
    [Test]
    public void GetAllPackageVersionsAsync_IncorrectPackageName_Exception()
    {
        // Arrange
        PackageHelper packageHelper = new();

        // Assert
        Assert.That(
            () => packageHelper.GetAllPackageVersionsAsync(
                string.Empty,
                default,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }

    [TestCase(-10)]
    [TestCase(0)]
    public void GetAllPackageVersionsAsync_IncorrectCount_Exception(int count)
    {
        // Arrange
        PackageHelper packageHelper = new();
        
        // Assert
        Assert.That(
            () => packageHelper.GetAllPackageVersionsAsync(
                "NUnit",
                count,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }

    [Test]
    public void GetAllPackageVersionsAsync_GetTenVersions_TenVersions()
    {
        // Arrange
        PackageHelper packageHelper = new();
        int versionCount = 10;

        // Act
        IEnumerable<string> versions = packageHelper.GetAllPackageVersionsAsync(
            "NUnit",
            versionCount, 
            CancellationToken.None).Result;

        // Assert
        Assert.That(versionCount, Is.EqualTo(versions.Count()));
    }

    [Test]
    public void GetPackagesAsync_IncorrectPackageName_Exception()
    {
        // Arrange
        PackageHelper packageHelper = new();

        // Assert
        Assert.That(
            () => packageHelper.GetPackagesAsync(
                string.Empty,
                default,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }

    [TestCase(-10)]
    [TestCase(0)]
    public void GetPackagesAsync_IncorrectCount_Exception(int count)
    {
        // Arrange
        PackageHelper packageHelper = new();

        // Assert
        Assert.That(
            () => packageHelper.GetPackagesAsync(
                "NUnit",
                count,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }

    [Test]
    public void GetPackagesAsync_GetTenPackages_TenPackages()
    {
        // Arrange
        PackageHelper packageHelper = new();
        int versionCount = 10;

        // Act
        IEnumerable<string> versions = packageHelper.GetPackagesAsync(
            "Test",
            10,
            CancellationToken.None).Result;

        // Assert
        Assert.That(versionCount, Is.EqualTo(versions.Count()));
    }

    [Test]
    public void GetAllPackageDependenciesAsync_IncorrectPackageName_Exception()
    {
        // Arrange
        PackageHelper packageHelper = new();

        // Assert
        Assert.That(
            () => packageHelper.GetAllPackageDependenciesAsync(
                string.Empty,
                string.Empty,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }

    [Test]
    public void GetAllPackageDependenciesAsync_IncorrectPackageVersion_Exception()
    {
        // Arrange
        PackageHelper packageHelper = new();

        // Assert
        Assert.That(
            () => packageHelper.GetAllPackageDependenciesAsync(
                "NUnit",
                string.Empty,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }

    [Test]
    public void GetAllPackageDependenciesAsync_PackageVersion_Exception()
    {
        // Arrange
        PackageHelper packageHelper = new();
        int countDependencies = 5;

        // Act
        IEnumerable<PackageIdentity> dependencies = packageHelper.GetAllPackageDependenciesAsync(
            "Microsoft.Extensions.DependencyInjection",
            "8.0.0",
            CancellationToken.None).Result;

        // Assert
        Assert.That(countDependencies, Is.EqualTo(dependencies.Count()));
    }
}
