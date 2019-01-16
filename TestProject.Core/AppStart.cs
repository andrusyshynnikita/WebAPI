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

        public AppStart(IMvxApplication app, IMvxNavigationService mvxNavigationService)
            : base(app, mvxNavigationService)
        {
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<MainViewModel>();
        }
    }

}
