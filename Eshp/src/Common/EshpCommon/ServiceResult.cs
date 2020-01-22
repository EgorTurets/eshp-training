using EshpCommon.Helpers;
using System;

namespace EshpCommon
{
    public class ServiceResult<T>
    {
        public bool IsErrored { get; private set; }

        public string ErrorMessage { get; private set; }

        public T Result { get; private set; }


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

        public ServiceResult<T> AppendErrorMessage(string message)
        {
            IsErrored = true;
            if (String.IsNullOrWhiteSpace(ErrorMessage))
            {
                ErrorMessage = message;
            }
            else
            {
                ErrorMessage = $"{ErrorMessage}\n{message}";
            }

            return this;
        }
    }
}
