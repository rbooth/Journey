using System;
using Journey.Core.Results;
using NUnit.Framework;

namespace Journey.Tests.Results
{
    [TestFixture]
    public class TestResultsCollection
    {
        [Test]
        public void PassedIsFalseWhenAnyFailureResultsExists()
        {
            var success = new SuccessResult("good");
            var pending = new PendingResult("pending");
            var failure = new FailureResult("bad", new Exception("djsfdsf"));

            var sut = new ResultCollection();
            sut.Add(success);
            sut.Add(pending);
            sut.Add(failure);

            Assert.IsFalse(sut.Passed.Value);
        }

        [Test]
        public void PassedIsFalsNullWhenPendingResultExistsWithNoFailures()
        {
            var success1 = new SuccessResult("good");
            var success2 = new SuccessResult("good");
            var success3 = new SuccessResult("good");
            var pending = new PendingResult("pending");

            var sut = new ResultCollection();
            sut.Add(success1);
            sut.Add(success2);
            sut.Add(pending);
            sut.Add(success3);

            Assert.IsNull(sut.Passed);
        }

        [Test]
        public void PassedIsTrueNullWhenNoFailureOrPending()
        {
            var success1 = new SuccessResult("good");
            var success2 = new SuccessResult("good");
            var success3 = new SuccessResult("good");

            var sut = new ResultCollection();
            sut.Add(success1);
            sut.Add(success2);
            sut.Add(success3);

            Assert.IsTrue(sut.Passed.Value);
        }
    }
}