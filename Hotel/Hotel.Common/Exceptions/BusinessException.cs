using System;

namespace Hotel.Common.Exceptions
{
    public class BusinessException: Exception
    {
        #region Properties
        /// <summary>
        /// Status code for the http response
        /// </summary>
        public int StatusCode { get; private set; }

        /// <summary>
        /// Message 
        /// </summary>
        public RuleError Result { get; private set; }
        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="statusCode">Status code for the http response</param>
        /// <param name="message">message of the exception</param>
        public BusinessException(int statusCode, string errorMessage, string messageOrigin = "", string attemptedValue = "", string propertyName = "")
        {
            StatusCode = statusCode;
            Result = new RuleError
            {
                AttemptedValue = attemptedValue,
                ErrorMessage = errorMessage,
                PropertyName = propertyName,
                MessageOrigin = !string.IsNullOrEmpty(messageOrigin) ? messageOrigin : string.Empty
            };
        }
        #endregion
    }
}
