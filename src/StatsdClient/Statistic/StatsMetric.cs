using System;
using StatsdClient.Aggregator;

namespace StatsdClient.Statistic
{
    /// <summary>
    /// Store the data for a metric.
    /// </summary>
    internal class StatsMetric
    {
        public StatsMetric()
        {
            Key = new MetricStatsKey(this);
        }
        public MetricStatsKey Key  {get; set;}
        

        public MetricType MetricType { get; set; }

        public string StatName { get; set; }

        public double NumericValue { get; set; } // Use for all `MetricType` excepts for `MetricType.Set`

        public string StringValue { get; set; } // Use only for `MetricType.Set`

        public double SampleRate { get; set; }

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