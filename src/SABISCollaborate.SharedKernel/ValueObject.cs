using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.SharedKernel
{
    public abstract class ValueObject
    {
        public int Id { get; protected set; }
    }
}
