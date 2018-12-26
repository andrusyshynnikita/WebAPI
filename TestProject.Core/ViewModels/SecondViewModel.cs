﻿using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Threading.Tasks;
using TestProject.Core.Interface;
using TestProject.Core.Models;

namespace TestProject.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel<TaskInfo>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ITaskService _taskService;

        public override async Task Initialize()
        {
            await base.Initialize();

        }

        public SecondViewModel(IMvxNavigationService mvxNavigationService, ITaskService taskService)
        {
            _taskService = taskService;
            _navigationService = mvxNavigationService;
            CloseCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<FirstViewModel>());
        }
        public IMvxAsyncCommand CloseCommand { get; set; }

        private int _id;
        private string _title;
        private string _description;
        private bool _status;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged(() => Status);
            }
        }
        public IMvxCommand SaveCommand
        {
            get { return new MvxCommand(SaveTask); }
            
        }

        public IMvxCommand DeleteCommand
        {
            get { return new MvxCommand(DeleteTask); }
        }

        private void SaveTask()
        {
            TaskInfo taskInfo = new TaskInfo(Id,Title, Description, Status);

                _taskService.InsertTask(taskInfo);
            _navigationService.Navigate<FirstViewModel>();
        }

        private void DeleteTask()
        {
            var position = Id;
            _taskService.DeleteTask(position);
            _navigationService.Navigate<FirstViewModel>();
        }

        public override void Prepare()
        {
            base.Prepare();
        }

        public override void Prepare(TaskInfo _taskInfo)
        {
            Id = _taskInfo.Id;
            Title = _taskInfo.Title;
            Description = _taskInfo.Description;
            Status = _taskInfo.Status;
        }
    }
}
