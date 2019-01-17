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
                ShowViewPager.Execute();
            });

            _mvxNavigationService = mvxNavigationService;
        }

        //public IMvxCommand ShowListItems { get; set; }
        public IMvxCommand LoginCommand => new MvxCommand(_loginService.LoginTwitter);
        //public IMvxCommand LogoutCommand => new MvxCommand(_loginService.Logout);
        
        public OAuth1Authenticator Authenticator
        {
            get
            {
                return _loginService.Authenticator();
            }
        }
        //public IMvxAsyncCommand ShowListItems
        //{
        //    get
        //    {
        //        return new MvxAsyncCommand(async () => {
        //            await _mvxNavigationService.Navigate<ListItemsViewModel>();
        //            await _mvxNavigationService.Close(this);
        //    });
        //    }
        //}

        public IMvxAsyncCommand ShowViewPager
        {
            get
            {
                return new MvxAsyncCommand(async () => {
                    await _mvxNavigationService.Navigate<ViewPagerViewModel>();
                    await _mvxNavigationService.Close(this);
                });
            }
        }

    }
}
