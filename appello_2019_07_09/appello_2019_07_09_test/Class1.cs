using appello_2019_07_09;
using NUnit.Framework;

namespace appello_2019_07_09_test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            string word = "cane";
            var expected = new List<string>() {"Cane", "cAne", "caNe", "canE", "Cane", "cAne", };
            Assert.That(expected,Is.EqualTo(word.MexicanWave().Take(6).ToList()));
        }

        [Test]
        public void Test2()
        {
            string word = "ga-to";
            Assert.Throws<ArgumentException>(() => word.MexicanWave().ToList());
        }
    }
}