using System;
using System.Collections.Generic;
using System.Linq;

namespace FastestMirror
{
    /// <summary>
    /// Resolves the fastest mirror from a collection of Uris.
    /// </summary>
    public class FastestMirrorResolver
    {
        private readonly IScore _score;

        /// <summary>
        /// Creates a new FastestMirrorResolver with a provided scoring algorithm.
        /// </summary>
        /// <param name="score">Scoring algorithm.</param>
        public FastestMirrorResolver(IScore score)
        {
            if (score == null)
                throw new ArgumentNullException("score");

            _score = score;
        }

        /// <summary>
        /// Resolves the fastest Uri in a collection.
        /// </summary>
        /// <param name="uris">Enumerable collection of Uris.</param>
        /// <returns>Fastest Uri in the collection.</returns>
        public Uri Fastest(IEnumerable<Uri> uris)
        {
            if (uris == null)
                throw new ArgumentNullException("uris");

            return uris.AsParallel()
                .OrderBy(_ => _score.Score(_.DnsSafeHost))
                .First();
        }
    }
}
