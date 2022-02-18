using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    class UserMenuView
    {
        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Просмотреть информацию о моем профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Напишите сообщение (нажмите 4)");
                Console.WriteLine("Посмотреть список исходящих (нажмите 5)");
                Console.WriteLine("Посмотреть список входящих (нажмите 6)");
                Console.WriteLine("Добавить в друзья (нажмите 7)");
                Console.WriteLine("Посмотреть список друзей (нажмите 8)");
                Console.WriteLine("Выйти из профиля (нажмите 9)");

                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.userDataUpdateView.Show(user);
                            break;
                        }
                    case "4":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }
                    case "5":
                        {
                            Program.userOutcomingMessageView.Show(user);
                            break;
                        }
                    case "6":
                        {

                            Program.userIncomingMessageView.Show(user);
                            break;
                        }
                    case "7":
                        {

                            Program.friendsAddingView.Show(user);
                            break;
                        }
                    case "8":
                        {

                            Program.friendsShowingView.Show(user);
                            break;
                        }
                    case "9":
                        {
                            return;
                        }
                }
            }
        }
    }
}
