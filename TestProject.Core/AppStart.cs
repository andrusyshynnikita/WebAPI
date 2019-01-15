using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using TestProject.Core.Interface;
using TestProject.Core.Models;
using TestProject.Core.services;
using TestProject.Core.ViewModels;

namespace TestProject.Core
{


    public class AppStart : MvxAppStart
    {
        IMvxNavigationService _mvxNavigationService;
        ILoginService _loginService;

        public AppStart(IMvxApplication app, IMvxNavigationService mvxNavigationService, ILoginService loginService)
            : base(app, mvxNavigationService)
        {
            _loginService = loginService;
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            if (_loginService.CurrentUserAccount != null)
            {
                TwitterUserId.Id_User = _loginService.CurrentUserAccount.Properties["user_id"];
                return NavigationService.Navigate<ListItemsViewModel>();
            }
            return NavigationService.Navigate<LoginViewModel>();

            
            

        }
    }

}
