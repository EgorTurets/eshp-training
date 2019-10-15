using EshpCommon.Helpers;

namespace EshpCommon
{
    public class ServiceResult<T>
    {
        public bool IsErrored { get; set; }

        public string ErrorMessage { get; set; }

        public T Result { get; set; }


        private ServiceResult (T result, bool isErrored, string errorMessage)
        {
            IsErrored = isErrored;
            ErrorMessage = errorMessage;
            Result = result;
        }

        public static ServiceResult<T> CreateErrorResult(string errorMessage)
        {
            return new ServiceResult<T>((T)DefaultValues.GetDefault(typeof(T)), true, errorMessage);
        }

        public static ServiceResult<T> CreateSuccessResult(T result)
        {
            return new ServiceResult<T>(result, false, null);
        }
    }
}
