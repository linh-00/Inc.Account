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
   public class NotFoundException : BaseException
    {
        public NotFoundException(ErrorMessage error)
                : base(error)
        {
        }
        public NotFoundException(ErrorMessage error, Exception innerException)
            : base(error, innerException)
        {
        }
        public NotFoundException(IEnumerable<ErrorMessage> erros, Exception exception)
            : base(erros, exception)
        {
        }
        public NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
