using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.ViewModels
{
   public class LoginViewModel : MvxViewModel
    {
        private IMvxNavigationService _mvxNavigationService;

        public LoginViewModel(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
            ShowListItems = new MvxAsyncCommand(async () => await _mvxNavigationService.Navigate<ListItemsViewModel>());
        }

        public IMvxCommand ShowListItems { get; set; }
    }
}
