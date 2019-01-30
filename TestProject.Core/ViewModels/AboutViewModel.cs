using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Interface;

namespace TestProject.Core.ViewModels
{
    public class AboutViewModel : MvxViewModel<Action>
    {

        //private readonly IMvxNavigationService _navigationService;
        //private ILoginService _loginService;

        public AboutViewModel()//IMvxNavigationService mvxNavigationService, ILoginService loginService)
        {
            //_navigationService = mvxNavigationService;
            //_loginService = loginService;
        }

        public IMvxCommand LogoutCommand => new MvxCommand(LogOut);

        private void LogOut()
        {
            //_loginService.Logout();
            //await _navigationService.Navigate<LoginViewModel>();
            //await _navigationService.Close(this);
            OnLoggedInHandler();
           // OnLoggedInHandlerIOS();
        }

        public override void Prepare(Action parameter)
        {
            OnLoggedInHandler = parameter;
        }

        public Action OnLoggedInHandler
        {
            get; set;
        }

        public static Action OnLoggedInHandlerIOS
        {
            get; set;
        }
    }
}
