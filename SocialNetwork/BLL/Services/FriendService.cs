using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            this.userRepository = new UserRepository();
            this.friendRepository = new FriendRepository();
        }

        public void AddAsFriend(AddingFriend person)
        {
            if (String.IsNullOrEmpty(person.Email)) throw new ArgumentNullException();

            var findPerson = this.userRepository.FindByEmail(person.Email);

            if (findPerson is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = person.UserId,
                friend_id = findPerson.id
            };

            if (this.friendRepository.Create(friendEntity) == 0) throw new Exception();
        }

        public IEnumerable<Friend> GetAllFriendsById(int userId)
        {
            var friends = new List<Friend>();

            var friends_enitites = friendRepository.FindAllByUserId(userId);

            friends_enitites.ToList().ForEach(f =>
            {
                var user = userRepository.FindById(f.friend_id);
                var name = user.firstname;
                var familyName = user.lastname;
                var email = user.email;

                friends.Add(new Friend(name, familyName, email));
            });

            return friends;
        }
    }
}
