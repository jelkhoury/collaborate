using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string PasswordHash(this string password)
        {
            return $"a+b=*{password}*b+a";
        }
    }
}
