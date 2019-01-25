using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using TestProject.Core.Interface;
using TestProject.Core.Models;
using Xamarin.Auth;

namespace TestProject.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private IMvxNavigationService _mvxNavigationService;
        private ILoginService _loginService;
        private Account _userDate;
        private TwitterUser _twitterUser;
        private OAuth1Authenticator _auth;


        public LoginViewModel(IMvxNavigationService mvxNavigationService, ILoginService loginService)
        {
            _loginService = loginService;

            _loginService.OnLoggedInHandler = new Action(() =>
            {
                ShowViewPager.Execute();
            });

            _mvxNavigationService = mvxNavigationService;
        }

        //public override Task Initialize()
        //{
        //    return base.Initialize();
        //}

        public IMvxCommand LoginCommand => new MvxCommand(_loginService.LoginTwitter);
        
        public OAuth1Authenticator Authenticator
        {
            get
            {
                return _loginService.Authenticator();
            }
        }

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

        public IMvxCommand ShowDoneList
        {
            get
            {
                return new MvxAsyncCommand(async () => {
                    await _mvxNavigationService.Navigate<DoneListItemViewModel>();
                    await _mvxNavigationService.Close(this);
                });
            }
        }

    }
}
