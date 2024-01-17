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
    internal static Color Error => Color.Red;

    /// <summary>
    /// Information text color.
    /// </summary>
    internal static Color Information => Color.LightBlue;

    /// <summary>
    /// Trace text color.
    /// </summary>
    internal static Color Trace => Color.Green;

    /// <summary>
    /// Warning text color.
    /// </summary>
    internal static Color Warning => Color.Yellow;

    #endregion Internal Properties
}
