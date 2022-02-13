using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    class UserMenuView
    {
        public void Show()
        {
            Console.WriteLine("Просмотреть информацию о моем профиле (нажмите 1)");
            Console.WriteLine("Редактировать мой профиль (нажмите 2)");
            Console.WriteLine("Добавить в друзья (нажмите 3)");
            Console.WriteLine("Напишите сообщение (нажмите 4)");
            Console.WriteLine("Посмотреть список исходящих (нажмите 5)");
            Console.WriteLine("Посмотреть список входящих (нажмите 6)");
            Console.WriteLine("Выйти из профиля (нажмите 7)");

            switch(Console.ReadLine().Trim().ToLower())
            {
                case "1":
                    {

                        break;
                    }
                case "2":
                    {
                        break;
                    }
                case "4":
                    {
                        break;
                    }
                case "5":
                    {    

                        break;
                    }
                case "6":
                    {
                       

                        break;
                    }
                case "7":
                    { 
                         break;
                    }
            }
        }
    }
}
