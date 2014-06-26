using Journey.Core.Results;
using NUnit.Framework;

namespace Journey.Tests.Results
{
    [TestFixture]
    public class PendingResultsTest
    {

        [Test]
        public void TestNameComesFromConstructor()
        {
            const string name = "mytest";
            var sut = new PendingResult(name);

            Assert.AreEqual(name, sut.TestName);
        }

        [Test]
        public void WasSuccessfuIsFalse()
        {
            var sut = new PendingResult("asas");

            Assert.IsNull(sut.WasSuccess);
        }

        [Test]
        public void MessageIsPending()
        {
            var sut = new PendingResult("asas");

            Assert.AreEqual("Pending", sut.Message);
        }
    }
}