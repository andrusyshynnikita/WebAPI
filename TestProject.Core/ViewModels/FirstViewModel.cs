using System;
using System.Threading.Tasks;
using System.Text;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Commands;

namespace TestProject.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public FirstViewModel()
        {
            _navigationService = _navigationService;
            ShowSecondPage = new MvxAsyncCommand(async () => await _navigationService.Navigate<SecondViewModel>());
        }

       public IMvxAsyncCommand ShowSecondPage { get; set; }


    }
}
