using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    class MainView
    {
        public void Show()
        {
            Console.WriteLine("Войти в профиль (нажмите 1):");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");
            Console.WriteLine("Выйти из программы (нажмите 3)");

            switch (Console.ReadLine().Trim().ToLower())
            {
                case "1":
                    {
                        Program.authenticationView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.registrationView.Show();
                        break;
                    }
                case "3":
                    {
                        break;
                    }

            }
        }
    }
}
