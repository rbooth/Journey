namespace Journey.Results
{
    public class SuccessResult : ITestResult
    {
        private readonly string _name;

        public SuccessResult(string name)
        {
            _name = name;
        }

        public string TestName
        {
            get { return _name; }
        }

        public bool? WasSuccess
        {
            get { return true; }
        }

        public string Message
        {
            get { return "Passed"; }
        }

        public string DetailedMessage
        {
            get { return string.Empty; }
        }
    }
}