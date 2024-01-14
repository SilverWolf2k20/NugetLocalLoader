namespace OkoloIt.NugetLocalLoader.Core.UnitTest;

[TestFixture]
internal sealed class PackageLoaderTests
{
    [Test]
    public void LoadPackageAsync_IncorrectPackageName_Exception()
    {
        // Arrange
        PackageLoader packageLoader = new();

        // Assert
        Assert.That(
            () => packageLoader.LoadPackageAsync(
                string.Empty,
                string.Empty,
                string.Empty,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }

    [Test]
    public void LoadPackageAsync_IncorrectPackageVersion_Exception()
    {
        // Arrange
        PackageLoader packageLoader = new();

        // Assert
        Assert.That(
            () => packageLoader.LoadPackageAsync(
                "NLog",
                string.Empty,
                string.Empty,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }

    [Test]
    public void LoadPackageAsync_IncorrectPath_Exception()
    {
        // Arrange
        PackageLoader packageLoader = new();

        // Assert
        Assert.That(
            () => packageLoader.LoadPackageAsync(
                "NLog",
                "6.0.0",
                string.Empty,
                CancellationToken.None).Wait(),
            Throws.Exception);
    }
}
