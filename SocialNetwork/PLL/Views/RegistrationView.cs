using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    class RegistrationView
    {
        UserService userService;

        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            Console.WriteLine("Для создания нового профиля введите ваше имя:");

            string fistName = Console.ReadLine();

            Console.Write("Ваша фамилия:");
            string lastName = Console.ReadLine();

            Console.Write("Пароль:");
            string password = Console.ReadLine();

            Console.Write("Почтовый адрес:");
            string email = Console.ReadLine();

            UserRegistrationData userRegistrationData = new UserRegistrationData()
            {
                FirstName = fistName,
                LastName = lastName,
                Password = password,
                Email = email
            };

            try
            {
                userService.Register(userRegistrationData);
                SuccessMessage.Show("Ваш профиль успешно создан.Теперь Вы можете войти в систему под своими учетными данными.");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка регистрации.");
            }
        }
    }
}
