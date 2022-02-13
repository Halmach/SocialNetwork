using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    class UserIncomingMessageView
    {
        MessageService messService;

        public UserIncomingMessageView(MessageService messService)
        {
            this.messService = messService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Список входящих сообщений");
            var outMessages = messService.GetInComingMessageById(user.Id);

            if (outMessages.ToList().Count() == 0)
            {
                Console.WriteLine("Сообщений нет");
                return;
            }

            outMessages.ToList().ForEach(m =>
            {
                Console.WriteLine("От кого:" + m.SenderEmail);
                Console.WriteLine("Текст сообщения:" + m.Content);
            });
        }
    }
}
