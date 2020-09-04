using System;

namespace StatsdClient.Statistic
{
    /// <summary>
    /// Store the data for an event.
    /// </summary>
    internal class StatsEvent
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string AlertType { get; set; }

        public string AggregationKey { get; set; }

        public string SourceType { get; set; }

        public int? DateHappened { get; set; }

        public string Priority { get; set; }

        public string Hostname { get; set; }

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