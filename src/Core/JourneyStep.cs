using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Journey.Core.Results;

namespace Journey.Core
{
    public class JourneyStep : ITestable
    {
        private readonly Action _action;
        private readonly string _testName;

        public JourneyStep(Action action, string testName)
        {
            _action = action;
            _testName = testName;
        }

        public IResult Execute()
        {
            try
            {
                _action();
                return new SuccessResult(_testName);
            }
            catch (NotImplementedException)
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