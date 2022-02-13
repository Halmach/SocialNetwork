using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Linq;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();
        public static MessageService messService = new MessageService();
        static void Main(string[] args)
        {
           Console.WriteLine("Добро пожаловать в социальную сеть.");
            bool authenticationDone = false;
           while (true) 
           { 
                Console.WriteLine("Войти в профиль (нажмите 1):");
                Console.WriteLine("Зарегистрироваться (нажмите 2)");
                Console.WriteLine("Выйти из программы (нажмите 3)");

                switch (Console.ReadLine().Trim().ToLower())
                {
                    case "1":
                        {
                            var authenticationData = new UserAuthenticationData();

                            Console.WriteLine("Введите почтовый адрес:");
                            authenticationData.Email = Console.ReadLine();

                            Console.WriteLine("Введите пароль:");
                            authenticationData.Password = Console.ReadLine();

                            try
                            {
                                User user = userService.Authenticate(authenticationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Вы успешно вошли в социальную сеть! Добро пожаловать {0}", user.FirstName);
                                authenticationDone = true;
                                Console.ForegroundColor = ConsoleColor.White;

                                while (authenticationDone)
                                {
                                    Console.WriteLine("Просмотреть информацию о моем профиле (нажмите 1)");
                                    Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                                    Console.WriteLine("Добавить в друзья (нажмите 3)");
                                    Console.WriteLine("Напишите сообщение (нажмите 4)");
                                    Console.WriteLine("Посмотреть список исходящих (нажмите 5)");
                                    Console.WriteLine("Посмотреть список входящих (нажмите 6)");
                                    Console.WriteLine("Выйти из профиля (нажмите 7)");

                                    switch (Console.ReadLine().Trim().ToLower())
                                    {
                                        case "1":
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Информация о моем профиле");
                                                Console.WriteLine("Мой идентификатор: " + user.Id);
                                                Console.WriteLine("Меня зовут: " + user.FirstName);
                                                Console.WriteLine("Моя фамилия: " + user.LastName);
                                                Console.WriteLine("Мой пароль: " + user.Password);
                                                Console.WriteLine("Мой почтовый адрес: " + user.Email);
                                                Console.WriteLine("Ссылка на мое фото: " + user.Photo);
                                                Console.WriteLine("Мой любимый фильм: " + user.FavoriteMovie);
                                                Console.WriteLine("Моя любимая книга: " + user.FavoriteBook);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                break;
                                            }
                                        case "2":
                                            {
                                                Console.Write("Меня зовут:");
                                                user.FirstName = Console.ReadLine();

                                                Console.Write("Моя фамилия:");
                                                user.LastName = Console.ReadLine();

                                                Console.Write("Ссылка на моё фото:");
                                                user.Photo = Console.ReadLine();

                                                Console.Write("Мой любимый фильм:");
                                                user.FavoriteMovie = Console.ReadLine();

                                                Console.Write("Моя любимая книга:");
                                                user.FavoriteBook = Console.ReadLine();

                                                userService.Update(user);

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Ваш профиль успешно обновлен!");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                break;

                                            }
                                        case "4":
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

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("Сообщение отправлено!");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                catch (ArgumentNullException)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Ошибка: Введите текст сообщения!");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                catch (ArgumentOutOfRangeException)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Ошибка: Сообщение превысело 5000 символов!");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                catch (UserNotFoundException)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Ошибка: Пользователя с таким почтовым адресом не существует!");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                break;
                                            }
                                        case "5":
                                            {
                                                Console.WriteLine("Список исходящих сообщений");
                                                var outMessages = messService.GetOutMessageById(user.Id);

                                                if (outMessages.ToList().Count() == 0)
                                                {
                                                    Console.WriteLine("Сообщений нет");
                                                    continue;
                                                }

                                                outMessages.ToList().ForEach( m =>
                                                  {
                                                      Console.WriteLine("Кому:" + m.RecipientEmail);
                                                      Console.WriteLine("Текст сообщения:" + m.Content);
                                                  });

                                                break;
                                            }
                                        case "6":
                                            {
                                                Console.WriteLine("Список входящих сообщений");
                                                var outMessages = messService.GetInComingMessageById(user.Id);

                                                if (outMessages.ToList().Count() == 0)
                                                {
                                                    Console.WriteLine("Сообщений нет");
                                                    continue;
                                                }

                                                outMessages.ToList().ForEach(m =>
                                                {
                                                    Console.WriteLine("От кого:" + m.SenderEmail);
                                                    Console.WriteLine("Текст сообщения:" + m.Content);
                                                });

                                                break;
                                            }
                                        case "7":
                                            {
                                                authenticationDone = false; break;
                                            }

                                    }
                                }
                            }
                            catch (WrongPasswordException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пароль не корректный!");
                            }
                            catch (UserNotFoundException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пользователь не найден!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;
                        }


                    case "2":
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

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ваш профиль успешно создан.Теперь Вы можете войти в систему под своими учетными данными.");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine("Введите корректное значение.");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Произошла ошибка регистрации.");
                            }

                            break;
                        }

                    case "3":
                        {
                            return;
                        }
                }

                Console.ReadLine();
           }
        }
    }
}
