namespace EshpCommon
{
    public class ServiceResult
    {
        public bool IsErrored { get; set; }

        public string ErrorMessage { get; set; }

        public object Result { get; set; }

        public ServiceResult() { }

        private ServiceResult (object result, bool isErrored, string errorMessage)
        {
            IsErrored = isErrored;
            ErrorMessage = errorMessage;
            Result = result;
        }

        public static ServiceResult CreateErrorResult(bool isErrored, string errorMessage)
        {
            return new ServiceResult(null, isErrored, errorMessage);
        }

        public static ServiceResult CreateSuccessResult(object result)
        {
            return new ServiceResult(result, false, null);
        }
    }
}
