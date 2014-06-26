using System;
using Journey.Core;
using Journey.Core.Results;
using NUnit.Framework;

namespace Journey.Tests.Results
{
    [TestFixture]
    public class TestJourneyStep
    {

        [Test]
        public void NoExceptionCreatesSuccessResult()
        {
            Action action = () => { };

            var sut = new JourneyStep(action, "test");

            var result = sut.Execute();

            Assert.IsInstanceOf<SuccessResult>(result);
        }

        [Test]
        public void NotImplementedExceptionCreatesPendingResult()
        {
            Action action = () => { throw new NotImplementedException(); };

            var sut = new JourneyStep(action, "test");

            var result = sut.Execute();

            Assert.IsInstanceOf<PendingResult>(result);
        }

        [Test]
        public void ExceptionsCreateFailureResults()
        {
            Action action = () => { throw new ApplicationException(); };

            var sut = new JourneyStep(action, "test");

            var result = sut.Execute();

            Assert.IsInstanceOf<FailureResult>(result);
        }
    }
}