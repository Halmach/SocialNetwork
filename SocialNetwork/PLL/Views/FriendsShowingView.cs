using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendsShowingView
    {
        FriendService friendService;

        public FriendsShowingView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Список ваших друзей:");
            var allfriends = friendService.GetAllFriendsById(user.Id);

            if (allfriends.ToList().Count() == 0)
            {
                Console.WriteLine("У вас пока нет друзей в списке");
                return;
            }

            Console.WriteLine();
            allfriends.ToList().ForEach(f =>
            {
                Console.WriteLine("Имя:" + f.Name);
                Console.WriteLine("Фамилия:" + f.FamilyName);
                Console.WriteLine("Email:" + f.Email);
                Console.WriteLine();
            });
        }
    }
}
