using Inc.Accounts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Shared.Exceptions.Exceptions
{
    public class AuthorizationException : BaseException
    {

        public AuthorizationException(ErrorMessage error)
           : base(error)
        {
        }

        public AuthorizationException(ErrorMessage error, Exception innerEception)
            : base(error, innerEception)
        {
        }
        public AuthorizationException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(errors, innerException)
        {
        }
        public AuthorizationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
