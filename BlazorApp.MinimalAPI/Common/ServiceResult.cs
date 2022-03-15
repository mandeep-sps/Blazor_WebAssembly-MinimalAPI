namespace BlazorApp
{
    public class ServiceResult1<T>
    {
        public T Data { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public bool IsSuccess => Exception == null && !HasValidationError;
        public bool HasValidationError { get; set; }

        public ServiceResult1(T data, string message, bool hasValidationError = false)
        {
            Data = data;
            Message = message;
            Exception = null;
            HasValidationError = hasValidationError;
        }

        public ServiceResult1(Exception exception, string message)
        {
            Exception = exception;
            Message = message;
            Data = default;
        }
    }
}
