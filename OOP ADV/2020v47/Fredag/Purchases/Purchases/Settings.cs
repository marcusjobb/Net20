namespace Purchases
{
    /// <summary>
    /// Program settings shared by all classes
    /// </summary>
    internal static class Settings
    {
        /// <summary>
        /// Sökväg till databasfilen
        /// </summary>
        internal static string Database { get; set; } = @".\MyPurchases.db";
    }
}