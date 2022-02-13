using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    class MessageSendingView
    {
        MessageService messService;

        public MessageSendingView(MessageService messService)
        {
            this.messService = messService;
        }

        public void Show(User user)
        {
            var sendingMessage = new SendingMessage();

            Console.Write("Введите почтовый адрес пользователя:");
            sendingMessage.RecipientEmail = Console.ReadLine();

            Console.Write("Введите текст сообщения (не больше 5000 символов):");
            sendingMessage.Content = Console.ReadLine();

            sendingMessage.Sender_id = user.Id;

            try
            {
                messService.SendMessage(sendingMessage);

                SuccessMessage.Show("Сообщение отправлено!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Ошибка: Введите текст сообщения!");
            }
            catch (ArgumentOutOfRangeException)
            {
                AlertMessage.Show("Ошибка: Сообщение превысело 5000 символов!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Ошибка: Пользователя с таким почтовым адресом не существует!");
            }
        }
    }
}
