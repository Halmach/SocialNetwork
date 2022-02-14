using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendsAddingView
    {
        FriendService friendService;

        public FriendsAddingView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var addingFriend = new AddingFriend();

            Console.Write("Введите почтовый адрес пользователя:");
            addingFriend.Email = Console.ReadLine();

            addingFriend.UserId = user.Id;

            try
            {
                friendService.AddAsFriend(addingFriend);

                SuccessMessage.Show("Пользователь теперь в списке ваших друзей!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Ошибка: Введите email!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Ошибка: Пользователя с таким почтовым адресом не существует!");
            }
        }
    }
}
