namespace FastestMirror
{
    /// <summary>
    /// Provides a method to compute a score for a hostname.
    /// </summary>
    public interface IScore
    {
        /// <summary>
        /// Computes a score for a hostname.
        /// </summary>
        /// <param name="host">Hostname to compute a score for.</param>
        /// <returns>Speed score.</returns>
        long Score(string host);
    }
}
