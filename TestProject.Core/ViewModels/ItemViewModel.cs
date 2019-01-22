using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;
using System.Threading.Tasks;
using TestProject.Core.Interface;
using TestProject.Core.Models;
using System;

namespace TestProject.Core.ViewModels
{
    public class ItemViewModel : MvxViewModel<TaskInfo>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ITaskService _taskService;
        private readonly IAudioService _audioService;
        private int _id;
        private string _title;
        private string _description;
        private bool _status;
        private bool _titleEnableStatus;
        private bool _saveTaskEnable;
        private bool _deleteTaskEnable;
        private bool _recordcheck;
        private bool _playdcheck;
        private bool _playRecordEnable;

        public override async Task Initialize()
        {
            await base.Initialize();

        }

        public ItemViewModel(IMvxNavigationService mvxNavigationService, ITaskService taskService, IAudioService audioService)
        {
            _taskService = taskService;
            _navigationService = mvxNavigationService;
            _audioService = audioService;
            IsPlayRecordingEnable = false;
            _audioService.OnPlaydHandler = new Action(() =>
            {
                IsPlayChecking = false;
            });

            _audioService.OnRecordHandler = new Action(() =>
            {
                IsPlayRecordingEnable = true;
            });
        }

        public IMvxCommand CloseCommand
        {
            get { return new MvxCommand(CloseTask); }
        }
        

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
                RaisePropertyChanged(() => IsDeletingTaskEnable);
            }
        }

        public string Title
        {
            get => _title;

            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
                RaisePropertyChanged(() => IsSavingTaskEnable);
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

        public IMvxCommand StartRecordingCommand
        {
            get { return new MvxCommand(StartRecording); }
        }

        public IMvxCommand PlayRecordingCommand
        {
            get { return new MvxCommand(PlayRecording); }
        }

        private void PlayRecording()
        {
            if (IsPlayChecking == true)
            {
                _audioService.PlayRecording(Id);
            }
            
            if(IsPlayChecking== false)
            {
                _audioService.StopPlayRecording();
            }
        }


        private void StartRecording()
        {
            if (IsREcordChecking == true)
            {
                _audioService.StartRecording(Id);
            }
           if(IsREcordChecking== false)
            {
                _audioService.StopRecording();
            }
        }

        private void CloseTask()
        {
            _audioService.DeleteNullFile();
            _navigationService.Close(this);
        }

        private void SaveTask()
        {
            TaskInfo taskInfo = new TaskInfo(Id, TwitterUserId.Id_User, Title, Description, Status);
            if (Title != null)
            {
                _taskService.InsertTask(taskInfo);
            }

            if (Id == 0 &&  _audioService.CheckAudioFile(Id)==true)
            {
                _audioService.RenameFile(taskInfo.Id);
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

            if(_audioService.CheckAudioFile(Id)== true)
            {
                IsPlayRecordingEnable = true;
            }
            else
            {
                IsPlayRecordingEnable = false;
            }

        }

        public bool IsTitleEnable
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

        public bool IsSavingTaskEnable
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

        public bool IsDeletingTaskEnable
        {
            get
            {
                if (_taskService.CurrentTask(Id)==null)
                {
                    _deleteTaskEnable = false;
                }
                else
                {
                    _deleteTaskEnable = true;
                }
                return _deleteTaskEnable;
            }
        }

        public bool IsREcordChecking
        {
            get => _recordcheck;

            set
            {
                _recordcheck = value;
                RaisePropertyChanged(() => IsREcordChecking);
            }
        }

        public bool IsPlayChecking
        {
            get => _playdcheck;

            set
            {
                _playdcheck = value;
                RaisePropertyChanged(() => IsPlayChecking);
            }
        }

        public bool IsPlayRecordingEnable
        {
            get
            {
                return _playRecordEnable;
            }

            set
            {
                _playRecordEnable = value;
                RaisePropertyChanged(() => IsPlayRecordingEnable);
            }
        }

    }
}
