using EshpCommon;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshpTests
{
    [TestFixture]
    public class CommonTest
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("Error Message")]
        public void ServiceResult_CreateErrorResult(string message)
        {
            ServiceResult<object> result = null;

            Assert.DoesNotThrow(() => result = ServiceResult<object>.CreateErrorResult(message));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
            Assert.AreEqual(message, result.ErrorMessage);
        }

        [Test]
        public void ServiceResult_CreateSuccessResult()
        {
            ServiceResult<object> result = null;

            Assert.DoesNotThrow(() => result = ServiceResult<object>.CreateSuccessResult(new object()));
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsErrored);
            Assert.IsInstanceOf(typeof(object), result.Result);
            Assert.IsNull(result.ErrorMessage);
        }

        [Test]
        public void ServiceResult_AppendErrorMessage_InitialSuccessResult_NewResult()
        {
            ServiceResult<object> initialResult = ServiceResult<object>.CreateSuccessResult(new object());

            ServiceResult<object> result = null;
            string errorMessage = "error";

            Assert.DoesNotThrow(() => result = initialResult.AppendErrorMessage(errorMessage));
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(object), result.Result);
            Assert.IsTrue(result.IsErrored);
            Assert.IsNotNull(result.Result);
            Assert.AreEqual(errorMessage, result.ErrorMessage);
        }

        [TestCase("message 1", "message 2")]
        public void ServiceResult_AppendErrorMessage_InitialErrorResult_AddErrorMessage(string error1, string error2)
        {
            var initialResult = ServiceResult<object>.CreateErrorResult(error1);

            ServiceResult<object> result = null;

            Assert.DoesNotThrow(() => result = initialResult.AppendErrorMessage(error2));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsErrored);
            Assert.AreEqual($"{error1}\n{error2}", result.ErrorMessage);
        }
    }
}
