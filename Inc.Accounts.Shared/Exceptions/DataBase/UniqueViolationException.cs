using Inc.Accounts.Shared.Exceptions.Exceptions;
using Inc.Accounts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Accounts.Shared.Exceptions.DataBase
{
    public class UniqueViolationException : BaseException
    {
        public UniqueViolationException(ErrorMessage error)
          : base(error)
        {
        }
        public UniqueViolationException(ErrorMessage error, Exception exception)
            : base(error, exception)
        {
        }
        public UniqueViolationException(IEnumerable<ErrorMessage> errors, Exception exception)
            : base(errors, exception)
        {
        }
        public UniqueViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

