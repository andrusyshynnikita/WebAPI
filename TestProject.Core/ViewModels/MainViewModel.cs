using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.Settings;
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

            if (CrossSettings.Current.Contains("Twitter") == true)
            {
                TwitterUserId.Id_User = CrossSettings.Current.GetValueOrDefault("Twitter", string.Empty).ToString();
                _mvxNavigationService.Navigate<ViewPagerViewModel>();
            }

            if (CrossSettings.Current.Contains("Twitter") == false)
            {
                _mvxNavigationService.Navigate<LoginViewModel>();
            }


        }
    }
}
