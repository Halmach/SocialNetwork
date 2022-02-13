using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;
using System;
using System.Linq;

namespace SocialNetwork
{
    class Program
    {
        static UserService userService = new UserService();
        static MessageService messService = new MessageService();

        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static UserIncomingMessageView userIncomingMessageView;


        static void Main(string[] args)
        {
            mainView = new MainView(); 
            authenticationView = new AuthenticationView(userService); 
            registrationView = new RegistrationView(userService);
            userMenuView = new UserMenuView(); 
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messService);
            userOutcomingMessageView = new UserOutcomingMessageView(messService);
            userIncomingMessageView = new UserIncomingMessageView(messService);

            bool exit = false;
            while(!exit)
            {
                exit = mainView.Show();
            }
           
        }
    }
}
