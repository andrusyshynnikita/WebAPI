using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IMvxNavigationService _mvxNavigationService;

        public MainViewModel( IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
            ShowLoginView = new MvxAsyncCommand(async () => await _mvxNavigationService.Navigate<LoginViewModel>());
        }

        public IMvxCommand ShowLoginView { get; set; }
    }
}
