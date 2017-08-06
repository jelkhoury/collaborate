using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model.Messages
{
    public class MessageReceiver : ValueObject
    {
        #region Properties
        public int TextMessageId { get; set; }
        public int UserId { get; set; }
        public bool IsRead
        {
            get
            {
                return this.ReadReceiptId.HasValue;
            }
        }
        public int? ReadReceiptId { get; set; }
        public virtual ReadReceipt ReadReceipt { get; set; }
        public int? DeliveryReceiptId { get; set; }
        #endregion

        #region Constructors
        private MessageReceiver()
        {

        }
        public MessageReceiver(int textMessageId, int userId) : this()
        {
            this.TextMessageId = textMessageId;
            this.UserId = userId;
        }
        #endregion
    }
}
