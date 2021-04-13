using System;
using System.Runtime.Serialization;

namespace Escola.Domain
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException() { }

        public ValidacaoException(string message) : base(message) { }

        public ValidacaoException(string message, Exception innerException) : base(message, innerException) { }

        protected ValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
