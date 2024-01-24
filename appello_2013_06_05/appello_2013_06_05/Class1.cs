namespace appello_2013_06_05
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            var numbers = Enumerable.Range(-3, 10);
            var pred = new List<Predicate<int>>()
            {
                i => i >= 0 && i % 2 == 0,
                i => i >= 0 && i % 2 != 0,
                i => i < -2
            };
            foreach (var partition in Classify(numbers, pred))
            {
                foreach (var item in partition)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            }
        }

        public static List<T>[] Classify<T>(IEnumerable<T> s, IEnumerable<Predicate<T>> p)
        {
            if(s == null || p == null)
                throw new ArgumentNullException();

            var res = new List<List<T>>();
            var toRemove = new List<T>();

            foreach (var pred in p)
            {
                var aux = new List<T>();

                foreach (var elem in s)
                {
                    if (pred(elem))
                    {
                        if (!toRemove.Contains(elem))
                        {
                            aux.Add(elem);
                            toRemove.Add(elem);
                        }
                    }
                }
                res.Add(aux);
            }
            if(toRemove.Count != s.Count())
                res.Add(s.Except(toRemove).ToList());
            return res.ToArray();
        }
    }
}