using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedManagmentSystem
{
    class Email
    {
        public string MessageType;
        public string Message;
        public Email(string MessageType, string Message)
        {
            this.MessageType = MessageType;
            this.Message = Message;
        }
        /// <summary>
        /// from the message, pulls out name, number, room, and description
        /// implementation of this is different for each separate type of message
        /// </summary>
        public void MessagePullDataOut()
        {

        }
    }
}
