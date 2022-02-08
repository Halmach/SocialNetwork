using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
           Console.WriteLine("Добро пожаловать в социальную сеть.");

           while(true) 
           { 
                Console.WriteLine("Для регистрации пользователя введите имя пользователя:");

                string fistName = Console.ReadLine();

                Console.Write("Фамилия:");
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
                    Console.WriteLine("Регистрация прошла успешно");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine(" Введите корректное значение. ");
                }
                catch (Exception)
                {
                    Console.WriteLine(" Произошла ошибка регистрации. ");
                }

                Console.ReadLine();
           }
        }
    }
}
