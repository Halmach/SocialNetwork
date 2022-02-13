using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    class SendingMessage
    {
        public string Content { get; set; }
        public int Sender_id { get; set; }
        public string RecipientEmail { get; set; }
    }
}
