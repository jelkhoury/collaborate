using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Users.Core
{
    public static class Constants
    {
        public class ExceptionCode
        {
            public static int UsernameAlreadyInUse = 900000;
            public static int EmailAlreadyInUse = 900001;
            public static int UsernameOrEmailAlreadyInUse = 900002;
        }
    }
}
