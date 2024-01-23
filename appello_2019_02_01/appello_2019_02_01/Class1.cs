namespace appello_2019_02_01
{
    public static class Class1
    {
        public static void Main()
        {
            var seq = new [] { 1, -6, 7, 4, 6, 2, -3, 4, -4 };
            foreach (var item in seq.EvenOddSwap())
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<T> EvenOddSwap<T>(this IEnumerable<T> seq)
        {
            if (seq == null)
                throw new ArgumentNullException();
            while (seq.Any())
            {
                var aux = seq.Take(2).ToArray();
                seq = seq.Skip(2);
                if (aux.Length == 1)
                    yield return aux[0];
                else
                {
                    yield return aux[1];
                    yield return aux[0];
                }
            }
        }
    }
}