using appello_2019_02_01;
using NUnit.Framework;

namespace appello_2019_02_01_test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void test1()
        {
            List<int> aux = null;
            Assert.Throws<ArgumentNullException>(() => aux.EvenOddSwap().ToList());
        }

        [Test]
        public void test2()
        {
            var list = new List<string>()
            {
                "Donald duck","Lowie","Dewey","Hewey","Scrooge mc Duck"
            };

            var expected = new List<string>()
            {
                "Lowie","Donald duck","Hewey","Dewey","Scrooge mc Duck"
            };

            Assert.That(list.EvenOddSwap(),Is.EqualTo(expected));
        }

    }
}