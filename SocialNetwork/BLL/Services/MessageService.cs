using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    class MessageService
    {
        IUserRepository userRepository;
        IMessageRepository messageRepository;

        public MessageService()
        {
            userRepository = new UserRepository();
            messageRepository = new MessageRepository();
        }

        public void SendMessage(SendingMessage sendmessageData)
        {
            if (String.IsNullOrEmpty(sendmessageData.Content)) throw new ArgumentNullException();

            if (sendmessageData.Content.Length > 5000) throw new ArgumentOutOfRangeException();

            var findRecipient = this.userRepository.FindByEmail(sendmessageData.RecipientEmail);

            if (findRecipient is null) throw new UserNotFoundException();

            var messageEntity = new MessageEntity()
            {
                content = sendmessageData.Content,
                sender_id = sendmessageData.Sender_id,
                recipient_id = findRecipient.id
            };

            if (this.messageRepository.Create(messageEntity) == 0) throw new Exception();
        }

        public IEnumerable<Message> GetInComingMessageById(int sender)
        {
            var messages = new List<Message>();

            var messages_enitites = messageRepository.FindByRecipientId(sender);

            messages_enitites.ToList().ForEach( m =>
            {
                var senderEmail = userRepository.FindById(m.sender_id).email;
                var recipientEmail = userRepository.FindById(m.recipient_id).email;

                messages.Add(new Message(m.id, m.content, senderEmail, recipientEmail));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutMessageById(int recipient)
        {
            var messages = new List<Message>();

            var messages_enitites = messageRepository.FindBySenderId(recipient);

            messages_enitites.ToList().ForEach(m =>
            {
                var senderEmail = userRepository.FindById(m.sender_id).email;
                var recipientEmail = userRepository.FindById(m.recipient_id).email;

                messages.Add(new Message(m.id, m.content, senderEmail, recipientEmail));
            });

            return messages;
        }
    }
}
