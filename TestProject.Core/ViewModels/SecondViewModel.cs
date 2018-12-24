using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Threading.Tasks;
using TestProject.Core.Interface;
using TestProject.Core.Models;

namespace TestProject.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
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

        private void SaveTask()
        {
            TaskInfo taskInfo = new TaskInfo(Title, Description, Status);
            _taskService.InsertTask(taskInfo);
            _navigationService.Navigate<FirstViewModel>();
        }
    }
}
