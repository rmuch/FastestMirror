using System;
using System.Linq;
using NUnit.Framework;

namespace FastestMirror.Tests
{
    [TestFixture]
    public class FastestMirrorResolverTests
    {
        private readonly string[] _testHosts =
        {
            "http://a.test",
            "http://b.test",
            "http://c.test"
        };

        private class TestScore : IScore
        {
            public long Score(string host)
            {
                switch (host)
                {
                    case "a.test":
                        return 285;
                    case "b.test":
                        return 192;
                    case "c.test":
                        return 350;
                    default:
                        return long.MaxValue - 1;
                }
            }
        }

        [Test]
        public void MirrorWithLowestScoreIsFastest()
        {
            var resolver = new FastestMirrorResolver(new TestScore());

            var uris = _testHosts.Select(_ => new Uri(_));

            var fastest = resolver.Fastest(uris);

            Assert.That(fastest.DnsSafeHost, Is.EqualTo("b.test"));
        }
    }
}
