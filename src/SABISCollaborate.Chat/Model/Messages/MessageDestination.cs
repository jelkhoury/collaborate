using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.System.Core.Model.Chat
{
    public class MessageDestination
    {
        #region Properties
        public int DestinationId { get; set; }

        public DestinationType DestinationType { get; set; }
        #endregion

        #region Constructors
        private MessageDestination()
        {

        }

        public MessageDestination(int Id, DestinationType type) : this()
        {
            this.DestinationId = Id;
            this.DestinationType = type;
        } 
        #endregion
    }
}
