using Moq;
using NUnit.Framework;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;
using System;
using System.Linq;

namespace SocialNetwork.Tests
{
    [TestFixture]
    class FriendServiceTests
    {
        [Test]
        public void FindAllByUserIdMustReturnAllFriendsOfUser()
        {
            var friendService = new FriendService();
            var userId = 3;
            Assert.That(friendService.GetAllFriendsById(userId).Any(friend => friend.Email == "large000@yandex.ru")); 
          //  Console.WriteLine(friendService.GetAllFriendsById(4).ToList().Count());
          //  Assert.That(true);
        }
    }
}
