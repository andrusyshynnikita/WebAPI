using TestProject.Core.Models;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using TestProject.Core.Interface;
using System.Threading.Tasks;

namespace TestProject.Core.ViewModels
{
    public class NotDoneListItemViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private MvxObservableCollection<TaskInfo> _taskCollection;
        private ITaskService _taskService;
        private MvxCommand _refreshCommand;
        private bool _isRefreshing;
        private ILoginService _loginService;

        public NotDoneListItemViewModel(IMvxNavigationService mvxNavigationService, ITaskService taskService, ILoginService loginService)
        {
            _navigationService = mvxNavigationService;
            _loginService = loginService;
          //  ShowSecondPageCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<ItemViewModel>());
            _taskService = taskService;
           // TaskViewCommand = new MvxAsyncCommand<TaskInfo>(NavigateMethod);

        }

        public IMvxCommand RefreshCommand => _refreshCommand = _refreshCommand ?? new MvxCommand(DoRefresh);

        private void DoRefresh()
        {
            IsRefreshing = true;
            var items = _taskService.GetAllNotDoneUserTasks(TwitterUserId.Id_User);
            TaskCollection = new MvxObservableCollection<TaskInfo>(items);
            IsRefreshing = false;
        }

        public IMvxCommand ShowSecondPageCommand { get; set; }

        public IMvxCommand<TaskInfo> TaskViewCommand { get; set; }

        public IMvxCommand LogoutCommand
        {
            get
            {
                return new MvxAsyncCommand(LogOut);
            }
        }

        private async Task NavigateMethod(TaskInfo taskInfo)
        {
            var result = await _navigationService.Navigate<ItemViewModel, TaskInfo>(taskInfo);
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
            var items = _taskService.GetAllNotDoneUserTasks(TwitterUserId.Id_User);
            TaskCollection = new MvxObservableCollection<TaskInfo>(items);
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged(() => IsRefreshing);
            }
        }

        private async Task LogOut()
        {

            _loginService.Logout();
            await _navigationService.Navigate<LoginViewModel>();
            await _navigationService.Close(this);
        }

    }

}
