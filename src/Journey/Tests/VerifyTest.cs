using System;
using Journey.Results;

namespace Journey.Tests
{
    public class VerifyTest : ITestable
    {
        private readonly Action _verifyAction;
        private readonly string _testName;

        public VerifyTest(Action verifyAction, string testName)
        {
            _verifyAction = verifyAction;
            _testName = testName;
        }

        public ITestResult Execute()
        {
            try
            {
                _verifyAction();
                return new SuccessResult(FormatTestName());
            }
            catch (NotImplementedException e)
            {
                return new PendingResult(_testName);
            }
            catch (Exception e)
            {
                return new FailureResult(FormatTestName(), e);
            }
        }

        private string FormatTestName()
        {
            return string.Format("\t\tVerify: {0}", _testName.UnCamel());
        }
    }
}