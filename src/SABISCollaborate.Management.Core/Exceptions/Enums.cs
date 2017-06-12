using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Registration.Core.Exceptions
{
    public enum ValidationExceptionCode : int
    {
        UsernameAlreadyInUse = 9000000
    }

    public static class Constants
    {
        public class ExceptionCode
        {
            public static int UsernameAlreadyInUse = 9000000;
        }
    }
}
