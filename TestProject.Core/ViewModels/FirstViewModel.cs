using TestProject.Core.Models;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using System.Collections.ObjectModel;
using TestProject.Core.services;

namespace TestProject.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private ObservableCollection<TaskInfo> _taskInfo;
        private TaskService _taskService;

        public FirstViewModel(IMvxNavigationService mvxNavigationService)
        {
            _navigationService = mvxNavigationService;
            ShowSecondPage = new MvxAsyncCommand(async () => await _navigationService.Navigate<SecondViewModel>());

        }

        public IMvxAsyncCommand ShowSecondPage { get; set; }
       
        
    }
}
