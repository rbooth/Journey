namespace Journey.Core.Results
{
    public interface IResult
    {
        string TestName { get; }
        bool? WasSuccess { get; }
        string Message { get; }
        string DetailedMessage { get; }
    }
}