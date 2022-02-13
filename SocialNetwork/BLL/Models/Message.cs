using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    class Message
    {
        public Message(int id, string content, string senderEmail, string recipientEmail)
        {
            Id = id;
            Content = content;
            SenderEmail = senderEmail;
            RecipientEmail = recipientEmail;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string SenderEmail { get; set; }

        public string RecipientEmail { get; set; }
    }
}
