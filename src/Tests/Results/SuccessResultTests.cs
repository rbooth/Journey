using Journey.Core.Results;
using NUnit.Framework;

namespace Journey.Tests.Results
{
    [TestFixture]
    public class SuccessResultTests
    {

        [Test]
        public void TestNameComesFromConstructor()
        {
            const string name = "mytest";
            var sut = new SuccessResult(name);

            Assert.AreEqual(name, sut.TestName);
        }

        [Test]
        public void MessageIsPassed()
        {
            var sut = new SuccessResult("mytest");

            Assert.AreEqual("Passed", sut.Message);
        }

        [Test]
        public void DetailedMessageIsEmpty()
        {
            var sut = new SuccessResult("mytest");

            Assert.AreEqual(string.Empty, sut.DetailedMessage);
        }

        [Test]
        public void WasSuccessfuIsTrue()
        {
            var sut = new SuccessResult("mytest");

            Assert.IsTrue(sut.WasSuccess.Value);
        }
    }
}
