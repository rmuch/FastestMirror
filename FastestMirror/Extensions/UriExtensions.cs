using System;
using System.Collections.Generic;

namespace FastestMirror.Extensions
{
    /// <summary>
    /// Provides extension methods for enumerable collections of Uris to resolve the fastest host in a collection.
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Resolves the fastest Uri in a collection.
        /// </summary>
        /// <param name="uris">Enumerable collection of Uris.</param>
        /// <returns>Fastest Uri in the collection.</returns>
        public static Uri Fastest(this IEnumerable<Uri> uris)
        {
            var resolver = new FastestMirrorResolver(new PingScore());

            return resolver.Fastest(uris);
        }
    }
}
