using Moq;
using NUnit.Framework;
using System.Linq;
using test_mio_per_Mock;

namespace test_mio_per_Mock_test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            var MockList = new List<Mock<test_mio_per_Mock.Class1.IMyinterface>>();
            for(int i=0;i<10;i++)
            {
                var mockElem = new Mock<test_mio_per_Mock.Class1.IMyinterface>();
                mockElem.Setup(mb => mb.Argomento1).Returns(i);
                mockElem.Setup(mb => mb.Argomento2).Returns(i + 1);
                MockList.Add(mockElem);
            }

            MockList.Select(s => s.Object).MyExtensionMethod(true).ToList();

            foreach (var item in MockList)
            {
                item.Verify(i=>i.Argomento1,Times.AtLeastOnce);
            }

            MockList.Select(s => s.Object).MyExtensionMethod(false).ToList();

            foreach (var item in MockList)
            {
                item.Verify(i => i.Argomento2, Times.AtLeastOnce);
            }
        }
    }
}