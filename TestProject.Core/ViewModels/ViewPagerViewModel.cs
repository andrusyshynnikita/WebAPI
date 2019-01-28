using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using TestProject.Core.Interface;

namespace TestProject.Core.ViewModels
{
    public class ViewPagerViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private ILoginService _loginService;

        public ViewPagerViewModel(IMvxNavigationService navigationService, ILoginService loginService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
            //  DoneListItemViewModel = Mvx.IoCConstruct<DoneListItemViewModel>();
            //  NotDoneListItemViewModel = Mvx.IoCConstruct<NotDoneListItemViewModel>();
            //  AboutViewModel = Mvx.IoCConstruct<AboutViewModel>();
            //  AboutViewModel.OnLoggedInHandler= new Action(() =>
            //{
            //    LogoutCommand.Execute();
            //});

            ShowDoneListItemViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<DoneListItemViewModel>());
            ShowNotDoneListItemViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<NotDoneListItemViewModel>());
            ShowAboutViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<AboutViewModel>());
        }

        public DoneListItemViewModel DoneListItemViewModel { get; set; }

        public NotDoneListItemViewModel NotDoneListItemViewModel { get; set; }

        public AboutViewModel AboutViewModel { get; set; }

        public IMvxCommand LogoutCommand
        {
            get
            {
                return new MvxAsyncCommand(LogOut);
            }
        }

        public IMvxAsyncCommand ShowDoneListItemViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowNotDoneListItemViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowAboutViewModelCommand { get; private set; }

        private async Task LogOut()
        {

            _loginService.Logout();
            await _navigationService.Navigate<LoginViewModel>();
            await _navigationService.Close(this);
        }
    }
}
