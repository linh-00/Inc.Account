using Inc.Accounts.Shared.Constants;
using Inc.Accounts.Shared.Enuns;
using Inc.Accounts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Shared.Exceptions.Exceptions
{
    public class RepositoryException : Exception
    {
        public IEnumerable<ErrorMessage> Errors { get; } = Array.Empty<ErrorMessage>();
        public HttpStatusCode StatusCode { get; }
        public RepositoryExceptionReason Reason { get; }

        public RepositoryException() { }
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(
            string message,
            Exception inner
        ) : base(message, inner) { }

        public RepositoryException(
            string message,
            IEnumerable<ErrorMessage> errors,
            HttpStatusCode statusCode
            ) : base(message)
        {
            Errors = errors;
            StatusCode = statusCode;
        }

        public RepositoryException(
           string message,
           string errorData,
           RepositoryExceptionReason reason = RepositoryExceptionReason.ThirdPartyServiceUnavailability) : base(message)
        {
            _ = Errors.Prepend(new ErrorMessage(ErrorCodes.RepositoryError, errorData));
            Reason = reason;
        }

        protected RepositoryException(
            SerializationInfo info,
#pragma warning disable SYSLIB0051 // O tipo ou membro é obsoleto
                    StreamingContext context) : base(info, context) { }
#pragma warning restore SYSLIB0051 // O tipo ou membro é obsoleto

    }
}

