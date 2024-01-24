using System.Security.Cryptography.X509Certificates;

namespace test_mio_per_Mock
{
    public static class Class1
    {
        public interface IMyinterface
        {
            public int Argomento1 { get; }
            public int Argomento2 { get; }
        }

        public class MyClass : IMyinterface
        {
           public int argomento1 { get; set; }
           public int argomento2 { get; set; }
            public int Argomento1 { get => argomento1; }
            public int Argomento2 { get => argomento2; }

            public MyClass(int argomento1, int argomento2)
            {
               this.argomento1 = argomento1;
               this.argomento2 = argomento2;
            }
        }

        public static void Main(string[] args)
        {
            var list = new List<MyClass>()
            {
                new MyClass(1,2),
                new MyClass(3,4),
                new MyClass(5,6),
                new MyClass(7,8)
            };
            foreach (var elem in list.MyExtensionMethod(true))
            {
                Console.WriteLine(elem);
            }
        }

        public static IEnumerable<int> MyExtensionMethod(this IEnumerable<IMyinterface> seq, bool pred)
        {
            if (seq == null)
                throw new ArgumentNullException();
            foreach (var elem in seq)
            {
                if (pred)
                    yield return elem.Argomento1;
                else yield return elem.Argomento2;
            }
        }
    }
}