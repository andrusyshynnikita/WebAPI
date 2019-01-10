using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Threading.Tasks;
using TestProject.Core.Interface;
using TestProject.Core.Models;

namespace TestProject.Core.ViewModels
{
    public class ItemViewModel : MvxViewModel<TaskInfo>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ITaskService _taskService;
        private int _id;
        private string _title;
        private string _description;
        private bool _status;
        private bool _titleEnableStatus;
        private bool _saveTaskEnable;

        public override async Task Initialize()
        {
            await base.Initialize();

        }

        public ItemViewModel(IMvxNavigationService mvxNavigationService, ITaskService taskService)
        {
            _taskService = taskService;
            _navigationService = mvxNavigationService;
            CloseCommand = new MvxAsyncCommand(async () => await _navigationService.Close(this)); 
        }
        public IMvxAsyncCommand CloseCommand { get; set; }

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
                RaisePropertyChanged(() => SaveTaskEnable);
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
            TaskInfo taskInfo = new TaskInfo(Id, TwitterUserId.Id_User, Title, Description, Status);
            if (Title != null)
            {
                _taskService.InsertTask(taskInfo);
            }

            _navigationService.Close(this);
        }

        private void DeleteTask()
        {
            var position = Id;

            _taskService.DeleteTask(position);

            _navigationService.Close(this);
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

        public bool TitleEnableStatus
        {
            get
            {
                if (Id == 0)
                {
                    _titleEnableStatus = true;
                }
                else
                {
                    _titleEnableStatus = false;
                }
                return _titleEnableStatus;
            }

        }
        
        public bool SaveTaskEnable
        {
            get
            {
                if (!string.IsNullOrEmpty(Title))
                {
                    _saveTaskEnable = true;
                }
                else
                {
                    _saveTaskEnable = false;
                }
                return _saveTaskEnable;
            }
        }
        
    }
}
