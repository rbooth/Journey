namespace Journey.Core.Results
{
    public class PendingResult : IResult
    {
        private readonly string _testName;

        public PendingResult(string testName)
        {
            _testName = testName;
        }

        public string TestName
        {
            get { return _testName; }
        }

        public bool? WasSuccess
        {
            get { return null; }
        }

        public string Message
        {
            get { return "Pending"; }
        }

        public string DetailedMessage
        {
            get { return string.Empty; }
        }
    }
}