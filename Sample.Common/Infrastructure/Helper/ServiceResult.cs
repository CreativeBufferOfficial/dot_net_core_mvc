namespace Sample.Common.Infrastructure.Helper
{
    public class ServiceResult<T>
    {
        public T Data { get; set; } // Holds the data returned by the service.
        public bool HasError { get; set; } // Indicates if an error occurred during service execution.
        public int ErrorCode { get; set; } // Error code associated with the error, if any.
        public string ErrorMessage { get; set; } // Error message describing the encountered error.
        public string SuccessMessage { get; set; } // Success message to provide feedback on successful operations.

        // Sets the data and resets error flags.
        public void SetData(T data)
        {
            HasError = false;
            Data = data;
        }

        // Sets the data, success message, and resets error flags.
        public void SetSuccess(T data, string successMessage = "")
        {
            HasError = false;
            Data = data;
            SuccessMessage = successMessage;
        }

        // Sets the error message, error code, and flags an error.
        public void SetError(string errorMessage, int errorCode = 0)
        {
            HasError = true;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}
