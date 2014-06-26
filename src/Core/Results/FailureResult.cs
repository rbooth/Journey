using System;

namespace Journey.Core.Results
{
    public class FailureResult : IResult
    {
        private readonly string _name;
        private readonly Exception _exception;

        public FailureResult(string name, Exception exception)
        {
            _name = name;
            _exception = exception;
        }

        public string TestName
        {
            get { return _name; }
        }

        public bool? WasSuccess
        {
            get { return false; }
        }

        public string Message
        {
            get { return "Failed"; }
        }

        public string DetailedMessage
        {
            get { return _exception.Message; }
        }
    }
}