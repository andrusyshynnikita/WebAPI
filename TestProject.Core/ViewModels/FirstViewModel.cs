using TestProject.Core.Models;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using System.Collections.ObjectModel;
using TestProject.Core.services;
using System.Collections.Generic;
using TestProject.Core.Interface;
using System.Threading.Tasks;

namespace TestProject.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        
        private MvxObservableCollection<TaskInfo> _taskCollection;

        private ITaskService _taskService;


        public FirstViewModel(IMvxNavigationService mvxNavigationService, ITaskService taskService)
        {
            _navigationService = mvxNavigationService;
            ShowSecondPage = new MvxAsyncCommand(async () => await _navigationService.Navigate<SecondViewModel>());
            _taskService = taskService;
            TaskViewCommand = new MvxAsyncCommand<TaskInfo>(Method);
        }

        public IMvxCommand ShowSecondPage { get; set; }

        public IMvxCommand<TaskInfo> TaskViewCommand { get; set; }
          
        public async Task Method(TaskInfo taskInfo)
        {
            var result = await _navigationService.Navigate<SecondViewModel, TaskInfo>(taskInfo);
        }
        public MvxObservableCollection<TaskInfo> TaskCollection
        {
            get
            {
                return _taskCollection;
            }
            set
            {
                _taskCollection = value;
                RaisePropertyChanged(() => TaskCollection);
            }
        }


        public override void ViewAppearing()
        {
            var items = _taskService.GetAllTaskData();
            TaskCollection = new MvxObservableCollection<TaskInfo>(items);
        }


    }

}

