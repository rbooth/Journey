namespace Journey.Results
{
    public interface ITestResult
    {
        string TestName { get; }
        bool? WasSuccess { get; }
        string Message { get; }
        string DetailedMessage { get; }
    }
}