using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Registration.Core.Model
{
    /// <summary>
    /// Read-only Position, in the registration context we can only consume a Position.
    /// </summary>
    public class Position : Entity
    {
        public string Title { get; protected set; }

        private Position()
        {

        }
    }
}
