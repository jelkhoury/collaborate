using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Registration.Core
{
    public abstract class ValueObject
    {
        public int Id { get; protected set; }
    }
}
