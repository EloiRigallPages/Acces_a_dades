namespace Botiga.Common
{
    public class Result
    {
        public bool IsOk { get; }
        public string? ErrorMessage { get; }
        public string? ErrorCode { get; }

        private Result(bool isOk, string? message = null, string? code = null)
        {
            IsOk = isOk;
            ErrorMessage = message;
            ErrorCode = code;
        }

        public static Result Ok() => new Result(true);

        public static Result Failure(string message, string code)
            => new Result(false, message, code);
    }
}
