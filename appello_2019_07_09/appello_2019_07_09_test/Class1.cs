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
        
        [TestCase(2, "pan")]
        public void Test3(int howmany, string word)
        {
            var res = word.MexicanWave().Take(howmany*word.Length).ToList();
            Assert.Multiple(() =>
            {
                foreach (var elem in res)
                {
                    Assert.That(elem.Length,Is.EqualTo(word.Length));
                    Assert.That(elem.Where(s=>char.IsUpper(s)).Count(),Is.EqualTo(1));
                    Assert.That(elem.Any(s=>!char.IsLetter(s)),Is.False);
                }
            });
        }
    }
}