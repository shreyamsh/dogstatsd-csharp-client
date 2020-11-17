using StatsdClient.Statistic;

namespace StatsdClient.Aggregator
{
    /// <summary>
    /// Aggregate <see cref="StatsMetric"/> instances of type <see cref="MetricType.Count"/>
    /// by summing the value by <see cref="MetricStatsKey"/>.
    /// </summary>
    internal class CountAggregator
    {
        private readonly AggregatorFlusher<StatsMetric> _aggregator;

        public CountAggregator(MetricAggregatorParameters parameters)
        {
            _aggregator = new AggregatorFlusher<StatsMetric>(parameters, MetricType.Count);
        }

        public void OnNewValue(ref StatsMetric metric)
        {
            var key = _aggregator.CreateKey(metric);

            // In order to aggregate count metrics, the sample rate must be the same.
            // On average, calling 1000 times `service.Increment(metricName, 1, sampleRate: 0.5);` generates arround
            // 500 `StatsMetric` objects with `NumericValue = 1` and `SampleRate = 0.5`. From the DogStatsd server perspective,
            // it is equivalent to generate 500 `StatsMetric` objects with `NumericValue = 2` and `SampleRate = 1`.
            // This code normalizes `StatsMetric.NumericValue` to always have `SampleRate = 1`.
            metric.NumericValue = metric.NumericValue / metric.SampleRate;

            if (_aggregator.TryGetValue(ref key, out var v))
            {
                v.NumericValue += metric.NumericValue;
                _aggregator.Update(ref key, v);
            }
            else
            {
                metric.SampleRate = 1.0;
                _aggregator.Add(ref key, metric);
            }

            this.TryFlush();
        }

        public void TryFlush(bool force = false)
        {
            _aggregator.TryFlush(
                values =>
                {
                    foreach (var keyValue in values)
                    {
                        _aggregator.FlushStatsMetric(keyValue.Value);
                    }
                },
                force);
        }
    }
}