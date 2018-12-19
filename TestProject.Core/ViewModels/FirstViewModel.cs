using TestProject.Core.Models;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using System.Collections.ObjectModel;
using TestProject.Core.services;
using System.Collections.Generic;
using TestProject.Core.Interface;

namespace TestProject.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private List<TaskInfo> _taskInfo;
        private MvxObservableCollection<TaskInfo> _getTaskInfo;

        private ITaskService _taskService;


        public FirstViewModel(IMvxNavigationService mvxNavigationService, ITaskService taskService)
        {
            _navigationService = mvxNavigationService;
            ShowSecondPage = new MvxAsyncCommand(async () => await _navigationService.Navigate<SecondViewModel>());
            _taskService = taskService;
            var item = _taskService.GetAllTaskData();
            _getTaskInfo = new MvxObservableCollection<TaskInfo>(item);
        }

        public IMvxAsyncCommand ShowSecondPage { get; set; }


        public MvxObservableCollection<TaskInfo> GetTaskInfo
        {
            get
            {
                return _getTaskInfo;
            }
            set
            {
                _getTaskInfo = value;
                RaisePropertyChanged(() => GetTaskInfo);
            }
        }





    }

}

