namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            this.Success = success;
        }

        public Result(bool success, string message):this(success)
        {
            this.Message = message;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
