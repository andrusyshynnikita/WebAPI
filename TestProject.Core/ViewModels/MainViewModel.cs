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
        ILoginService _loginService;

        public MainViewModel( IMvxNavigationService mvxNavigationService, ILoginService loginService)
        {
            _mvxNavigationService = mvxNavigationService;
            _loginService = loginService;
        }

        public IMvxCommand ShowCommand
        {
            get
            {
                return new MvxAsyncCommand(Showmathod);
            }
        }
        private async Task Showmathod()
        {
            if (_loginService.CurrentUserAccount != null)
            {
                TwitterUserId.Id_User = _loginService.CurrentUserAccount.Properties["user_id"];
                await _mvxNavigationService.Navigate<ViewPagerViewModel>();
            }

            if (_loginService.CurrentUserAccount == null)
            {
                await _mvxNavigationService.Navigate<LoginViewModel>();
            }
               
        }

    }
}
