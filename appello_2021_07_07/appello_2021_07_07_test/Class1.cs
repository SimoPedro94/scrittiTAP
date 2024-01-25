using appello_2021_07_07;
using NUnit.Framework;

namespace appello_2021_07_07_test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            var seq = new List<double>() { 42.0, 49.0, 47.0, 18.0, 19.0, 28.0, 26.0 };
            Assert.Throws<appello_2021_07_07.Class1.FiniteSourceException>(() => seq.Smooth(2).ToList());
        }

        [Test]
        public void Test2()
        {
            var seq = appello_2021_07_07.Class1.InfiniteSeq();
            Assert.Throws<ArgumentOutOfRangeException>(() => seq.Smooth(-1).ToList());
        }

        [TestCase(2,new[]{0,1,2},new[]{0,1,2,1,2,1,2},4)]
        public void Test3(int N, double[] sourceSample, double[] expectedSample, int howMany)
        {
            var seqSource = InfiniteRepeat(sourceSample);
            var seqExp = InfiniteRepeat(expectedSample);
            Assert.That(seqSource.Smooth(N).Take(howMany),Is.EqualTo(seqExp.Take(howMany)));
        }

        private IEnumerable<double> InfiniteRepeat(IEnumerable<double> to_repeat)
        {
            while (true)
            {
                foreach (var elem in to_repeat)
                {
                    yield return elem;
                }
            }
        }
    }
}