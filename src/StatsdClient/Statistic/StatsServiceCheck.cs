using System;

namespace StatsdClient.Statistic
{
    /// <summary>
    /// Store the data for a service check.
    /// </summary>
    internal class StatsServiceCheck
    {
        public string Name { get; set; }

        public int Status { get; set; }

        public int? Timestamp { get; set; }

        public string Hostname { get; set; }

        public string ServiceCheckMessage { get; set; }

        public bool TruncateIfTooLong { get; set; }

        public string[] Tags { get; set; }

        public override bool Equals(object obj)
        {
            throw new NotSupportedException("The default implementation has performance issues.");
        }

        public override int GetHashCode()
        {
            throw new NotSupportedException("The default implementation has performance issues.");
        }
    }
}