using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.ViewModels;
using TestProject.IOS.Sources;
using UIKit;

namespace TestProject.IOS
{
    [MvxTabPresentation(WrapInNavigationController = false, TabName = "NotDoneTasks")]
    public partial class NotDoneListItemView : MvxViewController<NotDoneListItemViewModel>
    {
        private UIBarButtonItem _btnCAdd;

        public NotDoneListItemView() : base(nameof(NotDoneListItemView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _btnCAdd = new UIBarButtonItem(UIBarButtonSystemItem.Add, null);
            NavigationItem.SetRightBarButtonItem(_btnCAdd, false);

            var source = new TasksTableViewSource(NotDoneTasksTableView);
            NotDoneTasksTableView.Source = source;

            var set = this.CreateBindingSet<NotDoneListItemView, NotDoneListItemViewModel>();
            set.Bind(source).To(vm => vm.TaskCollection);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.TaskViewCommand);
            set.Bind(_btnCAdd).For("Clicked").To(vm => vm.ShowSecondPageCommand);
            set.Apply();

            NotDoneTasksTableView.ReloadData();
        }
    }
}