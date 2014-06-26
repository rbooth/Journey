using System;
using System.Collections.Generic;
using Journey.Core;
using Journey.Core.Results;
using NUnit.Framework;

namespace Journey.Tests.Results
{
    [TestFixture]
    public class FailureResultTests
    {
        private const string TEST_NAME = "mytest";

        [Test]
        public void TestNameComesFromConstructor()
        {
            var sut = new FailureResult(TEST_NAME, new Exception());

            Assert.AreEqual(TEST_NAME, sut.TestName);
        }

        [Test]
        public void MessageIsExceptionMessage()
        {
            const string exceptionMessage = "this is bad.";
            var sut = new FailureResult(TEST_NAME, new Exception(exceptionMessage));

            Assert.AreEqual("Failed", sut.Message);
        }

        [Test]
        public void DetailedMessageIsExceptionStackTrace()
        {
            const string stacktrace = "some stack trace error of code issues";
            var exception = new TestException("msg", stacktrace);
            
            var sut = new FailureResult(TEST_NAME, exception);


            Assert.AreEqual(exception.Message, sut.DetailedMessage);

        }

        [Test]
        public void WasSuccessfuIsFalse()
        {
            var sut = new FailureResult(TEST_NAME, new Exception());

            Assert.IsFalse(sut.WasSuccess.Value);
        }

        public class TestException : Exception
        {
            private readonly string _stacktrace;

            public TestException(string message, string stacktrace): base(message)
            {
                _stacktrace = stacktrace;
            }

            public override string StackTrace
            {
                get { return _stacktrace; }
            }
        }
    }
}