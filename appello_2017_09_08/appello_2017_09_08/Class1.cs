namespace appello_2017_09_08
{
    public static class Class1
    {
        public static void Main(string[] args)
        {
            var seq = new string[] { "a 0", "b 1", "c 2", "d 3", "e 4", "f 5", "g 6" };
            Console.Write(" First 2 elements on some prime position are: ");
            foreach (var s in seq.TakePrime(2))
                Console.Write("{0} ,", s);
            Console.WriteLine();
            Console.Write(" First 100 elements on some prime position are: ");
            foreach (var s in seq.TakePrime(100))
                Console.Write(" {0} ,", s);
            Console.WriteLine();
        }

        public static IEnumerable<T> TakePrime<T>(this IEnumerable<T> s, int count)
        {
            if (s == null)
                throw new ArgumentNullException();
            if(count < 1)
                throw new ArgumentOutOfRangeException();
            var E_s = s.GetEnumerator();
            int i = 0;
            int aux = 0;
            while(E_s.MoveNext()) 
            {
                if(i == count)
                    yield break;
                if (IsPrimo(aux))
                {
                    i++;
                    yield return E_s.Current;
                }
                aux++;
            }
        }

        private static bool IsPrimo(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}