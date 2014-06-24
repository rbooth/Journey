using System;
using Journey.Results;

namespace Journey.Tests
{
    public class TestStep : ITestable
    {
        private readonly Action _action;
        private readonly string _testName;

        public TestStep(Action action, string testName)
        {
            _action = action;
            _testName = testName;
        }

        public ITestResult Execute()
        {
            try
            {
                _action();
                return new SuccessResult(_testName);
            }
            catch (NotImplementedException e)
            {
                return new PendingResult(_testName);
            }
            catch (Exception e)
            {
                return new FailureResult(_testName, e);
            }
        }
    }
}