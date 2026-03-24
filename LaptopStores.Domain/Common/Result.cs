namespace LaptopStores.Domain.Common
{
    public class Result // Just true or false + why it fails
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public static Result Success(string message)
        {
            return new Result(true, message ?? string.Empty);
        }
        public static Result Failure(string message) => new Result(false, message);
    }

    public class Result<T> : Result // true or false + why it fails + data (if success)
    {
        private readonly T? _value;
        public T Value => IsSuccess
            ? _value! // ! means "It's 100% not null"
            : throw new InvalidOperationException("Cannot access value when Result fail");

        protected Result(T? value, bool isSuccess, string message)
            : base(isSuccess, message)
        {
            _value = value;
        }

        // Factory method for success (returns the value)
        public static Result<T> Success(T value, string message) => new Result<T>(value, true, message);

        // Factory method for fail (returns the T default)
        public new static Result<T> Failure(string message) => new Result<T>(default, false, message);
    }
}