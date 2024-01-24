using appello_2017_09_08;
using NUnit.Framework;

namespace appello_2017_09_08_test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            var list = Enumerable.Range(0, 20);
            var expected = new List<int>() {2,3,5,7,11,13};
            Assert.That(expected,Is.EqualTo(list.TakePrime(6)));
        }

        [TestCase(2)]
        [TestCase(3)]
        public void Test2(int b)
        {
            var list = InfinitePow(b);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.TakePrime(0).ToList());
        }

        [TestCase(7)]
        [TestCase(10)]
        public void Test3(int size)
        {
            var list = InfiniteSeq().TakePrime(size);
            var res = list.GetEnumerator();
            Assert.Multiple(() =>
            {
                Assert.That(list.Count(),Is.EqualTo(size));
                res.MoveNext();
                var aux = res.Current;
                while (res.MoveNext())
                {
                    Assert.IsTrue(res.Current > aux);
                }
            });
        }

        private IEnumerable<int> InfinitePow(int n)
        {
            int i = n;
            while (true)
            {
                yield return i;
                i = n * i;
            }
        }

        private IEnumerable<int> InfiniteSeq()
        {
            int i = 0;
            while (true)
            {
                yield return i;
                i++;
            }
        }
    }
}