using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using TestProject.Core.Interface;
using TestProject.Core.Models;
using Xamarin.Auth;

namespace TestProject.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel//, ILoginHandler
    {
        private IMvxNavigationService _mvxNavigationService;
        private ILoginService _loginService;
        private Account _userDate;
        private TwitterUser _twitterUser;
        private OAuth1Authenticator _auth;

        public LoginViewModel(IMvxNavigationService mvxNavigationService, ILoginService loginService)
        {
          //  ShowListItems = new MvxAsyncCommand(async () => await _mvxNavigationService.Navigate<ListItemsViewModel>());
            _loginService = loginService;

            _loginService.OnLoggedInHandler = new Action(() =>
            {
                ShowListItems.Execute();
            });

            _mvxNavigationService = mvxNavigationService;
            ShowViewPager = new MvxAsyncCommand(async () => await _mvxNavigationService.Navigate<ViewPagerViewModel>());
        }

        //public IMvxCommand ShowListItems { get; set; }
        public IMvxCommand ShowViewPager { get; set; }
        public IMvxCommand LoginCommand => new MvxCommand(_loginService.LoginTwitter);
        //public IMvxCommand LogoutCommand => new MvxCommand(_loginService.Logout);
        
        public OAuth1Authenticator Authenticator
        {
            get
            {
                return _loginService.Authenticator();
            }
        }
        public IMvxAsyncCommand ShowListItems
        {
            get
            {
                return new MvxAsyncCommand(async () => {
                    await _mvxNavigationService.Navigate<ListItemsViewModel>();
                    await _mvxNavigationService.Close(this);
            });
            }
        }

        //private async void LoginInTwitter()
        //{
        //    _loginService.LoginTwitter();
        //    _loginService.Authenticator().Completed += twitter_auth_Completed;
        //}
        //async private void twitter_auth_Completed(object sender, AuthenticatorCompletedEventArgs eventArgs)
        //{

        //    if (eventArgs.IsAuthenticated)
        //    {
        //        Account loggedInAccount = eventArgs.Account;

        //        AccountStore.Create().Save(loggedInAccount, "Twitter");

        //        var request = new OAuth1Request("GET",
        //            new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"),
        //            null,
        //            eventArgs.Account);

        //        var response = await request.GetResponseAsync();

        //        var json = response.GetResponseText();

        //        _twitterUser = JsonConvert.DeserializeObject<TwitterUser>(json);
        //        var data = AccountStore.Create().FindAccountsForService("Twitter").FirstOrDefault();
        //        data.Username = _twitterUser.name;
        //        TwitterUserId.Id_User = data.Properties["user_id"];

        //        //TwitterUserId.Id_User = _twitterUser.id;
        //        // StoringDataIntoCache(_twitterUser);
        //        ShowListItems.Execute();
        //    }

        //}
    }
}
