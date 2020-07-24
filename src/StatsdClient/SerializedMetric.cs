using System.Text;
using StatsdClient.Utils;

namespace StatsdClient
{
    internal class SerializedMetric : AbstractPoolObject
    {
        public SerializedMetric(Pool<SerializedMetric> pool)
        : base(pool)
        {
        }

        public StringBuilder Builder { get; } = new StringBuilder();

        public int CopyToChars(char[] charsBuffers)
        {
            var length = Builder.Length;
            if (length > charsBuffers.Length)
            {
                return -1;
            }

            Builder.CopyTo(0, charsBuffers, 0, length);
            return length;
        }

        public override string ToString()
        {
            return Builder.ToString();
        }

        public override void Reset()
        {
            Builder.Clear();
        }
    }
}
