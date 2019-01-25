using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Interface;
using TestProject.Core.Models;

namespace TestProject.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IMvxNavigationService _mvxNavigationService;
        private ILoginService _loginService;

        public MainViewModel( IMvxNavigationService mvxNavigationService, ILoginService loginService)
        {
            _loginService = loginService;
            _mvxNavigationService = mvxNavigationService;
            ShowCurrentViewModelCommand = new MvxAsyncCommand(ShowCurrentViewModel);
        }

        public IMvxAsyncCommand ShowCurrentViewModelCommand { get; private set; }

        private async Task ShowCurrentViewModel()
        {

            //if (_loginService.CurrentUserAccount != null)
            //{
            //    TwitterUserId.Id_User = _loginService.CurrentUserAccount.Properties["user_id"];
            //   _mvxNavigationService.Navigate<ViewPagerViewModel>();
            //}

         //   if (_loginService.CurrentUserAccount == null)
          //  {
                _mvxNavigationService.Navigate<LoginViewModel>();
           // }
               

        }
    }
}
