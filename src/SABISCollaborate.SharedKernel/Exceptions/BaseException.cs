using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.SharedKernel.Exceptions
{
    public abstract class BaseException : Exception
    {
        public abstract int Code { get; }

        public BaseException() : this("")
        {

        }

        public BaseException(string message) : base(message)
        {

        }
    }
}
