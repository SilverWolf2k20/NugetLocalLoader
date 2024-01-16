using System.Drawing;

namespace OkoloIt.NugetLocalLoader.Cli.Helpers;

/// <summary>
/// Standard output colors.
/// </summary>
internal static class CliColors
{
    #region Internal Properties

    /// <summary>
    /// Error text color.
    /// </summary>
    internal static Color Error => Color.FromArgb(182, 0, 20);

    /// <summary>
    /// Information text color.
    /// </summary>
    internal static Color Information => Color.FromArgb(0, 72, 128);

    /// <summary>
    /// Warning text color.
    /// </summary>
    internal static Color Warning => Color.FromArgb(241, 210, 46);

    #endregion Internal Properties
}
