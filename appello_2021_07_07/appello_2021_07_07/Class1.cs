namespace appello_2021_07_07
{
    public static class Class1
    {
        public static void Main(string[] args)
        {
            var seq = //new double[] { 2, 4, 6, 8, 10, 12,2,4,6,8,10,12 };
            InfiniteSeq();
            foreach (var elem in seq.Smooth(3).Take(10).ToList())
            {
                Console.WriteLine(elem);
            }
        }

        public static IEnumerable<double> InfiniteSeq()
        {
            var i = 1;
            while (true)
            {
                yield return i;
                i++;
            }
        }

        public static IEnumerable<double> Smooth(this IEnumerable<double> s, int N)
        {
            if (s == null)
                throw new ArgumentNullException();
            if (N < 0)
                throw new ArgumentOutOfRangeException();
            using (var enumerator = s.GetEnumerator())
            {
                var buffer = new List<double>();

                for (int i = 0; i <= N && enumerator.MoveNext(); i++)
                    buffer.Add(enumerator.Current);

                while (true)
                {
                    double average = buffer.Average();

                    yield return average;

                    buffer.RemoveAt(0);

                    if (enumerator.MoveNext())
                        buffer.Add(enumerator.Current);
                    else
                        throw new FiniteSourceException("La sorgente è finita.");
                }
            }
        }

        public class FiniteSourceException : Exception
        {
            public FiniteSourceException(string message) : base(message)
            {
            }
        }
    }
}

