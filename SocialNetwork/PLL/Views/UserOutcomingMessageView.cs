using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    class UserOutcomingMessageView
    {
        MessageService messService;

        public UserOutcomingMessageView(MessageService messService)
        {
            this.messService = messService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Список исходящих сообщений");
            var outMessages = messService.GetOutMessageById(user.Id);

            if (outMessages.ToList().Count() == 0)
            {
                Console.WriteLine("Сообщений нет");
                return;
            }

            outMessages.ToList().ForEach(m =>
            {
                Console.WriteLine("Кому:" + m.RecipientEmail);
                Console.WriteLine("Текст сообщения:" + m.Content);
            });
        }
    }
}
