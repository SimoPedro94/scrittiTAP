using NUnit.Framework;

namespace appello_2013_06_05_test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            var numbers = Enumerable.Range(-3, 10);
            var pred = new List<Predicate<int>>()
            {
                i => i >= 0 && i % 2 == 0,
                i => i >= 0 && i % 2 != 0,
                i => i < -2
            };
            var expected = new List<int>[]
            {
                new List<int>{0,2,4,6},
                new List<int>{1,3,5},
                new List<int>{-3},
                new List<int>{-2,-1}
            };
            Assert.That(expected,Is.EqualTo(appello_2013_06_05.Class1.Classify(numbers,pred)));
        }

        [Test]
        public void Test2()
        {
            var numbers = Enumerable.Range(-3, 10);
            List<Predicate<int>> pred = null;
            List<int>[] expected = null;
            Assert.Throws<ArgumentNullException>(() => appello_2013_06_05.Class1.Classify(numbers, pred).ToList());
        }
    }
}