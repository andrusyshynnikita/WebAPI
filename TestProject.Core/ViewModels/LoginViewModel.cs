using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public LoginViewModel(IMvxNavigationService mvxNavigationService, ILoginService loginService)
        {
            //_loginService = loginService;
            //_userDate = _loginService.GetActiveTwitterUser();
            //TwitterUserId.Id_User = _userDate.Username;
            _mvxNavigationService = mvxNavigationService;
            ShowListItems = new MvxAsyncCommand(async () => await _mvxNavigationService.Navigate<ListItemsViewModel>());
        }

        public IMvxCommand ShowListItems { get; set; }

        //public void OnLoginHandler()
        //{
         
        //    throw new NotImplementedException();
        //}
        
    }
}
