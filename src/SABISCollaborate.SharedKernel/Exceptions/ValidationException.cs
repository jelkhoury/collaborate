using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.SharedKernel.Exceptions
{
    public class ValidationException : BaseException
    {
        public override int Code { get; }

        public ValidationException(int code) : this(code, "")
        {
        }

        public ValidationException(int code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
