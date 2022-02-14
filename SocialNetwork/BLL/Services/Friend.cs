using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Services
{
    public class Friend
    {
        public Friend(string name, string familyName, string email)
        {
            Name = name;
            FamilyName = familyName;
            Email = email;
        }

        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
    }
}
