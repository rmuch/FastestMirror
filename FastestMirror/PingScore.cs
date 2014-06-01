using System.Net.NetworkInformation;

namespace FastestMirror
{
    /// <summary>
    /// Computes a speed score based on ICMP ping round trip time.
    /// </summary>
    public class PingScore : IScore
    {
        /// <summary>
        /// Gets or sets the duration to be spent waiting for a ping response, in milliseconds.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Creates a new instance of PingStore with a 1000ms timeout.
        /// </summary>
        public PingScore() : this(1000) { }

        /// <summary>
        /// Creates a new instance of PingStore with a specified timeout.
        /// </summary>
        /// <param name="timeout">Duration to be spent waiting for a ping response, in milliseconds.</param>
        public PingScore(int timeout)
        {
            Timeout = timeout;
        }

        /// <summary>
        /// Computes the ICMP ping round trip time for a specified hostname, completing within the specified tiemout.
        /// </summary>
        /// <param name="host">Hostname to test.</param>
        /// <returns>Ping response time in milliseconds.</returns>
        public long Score(string host)
        {
            try
            {
                var ping = new Ping();

                var reply = ping.Send(host, Timeout);

                if (reply != null && reply.Status == IPStatus.Success)
                    return reply.RoundtripTime;
                else
                    return long.MaxValue - 1;
            }
            catch (PingException ex)
            {
                return long.MaxValue;
            }
        }
    }
}
