using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.SharedKernel.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public abstract int Code { get; }

        public ExceptionBase() : this("")
        {

        }

        public ExceptionBase(string message) : base(message)
        {

        }
    }
}
