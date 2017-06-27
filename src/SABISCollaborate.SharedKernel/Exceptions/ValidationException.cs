using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.SharedKernel.Exceptions
{
    public class ValidationException : ExceptionBase
    {
        public override int Code { get; }

        public ValidationException(int code) : this(code, "") { }

        public ValidationException(int code, string message) : base(message)
        {
            // validation exceptions code should have be 90XXXX
            if (code < 900000 || this.Code > 909999)
            {
                throw new Exception("Validation exception code should match the Format 90XXXXX");
            }

            this.Code = code;
        }
    }
}
