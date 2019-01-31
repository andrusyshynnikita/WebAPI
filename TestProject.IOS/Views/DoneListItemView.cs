using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.ViewModels;
using TestProject.IOS.Sources;
using TestProject.IOS.Views.Cells;
using UIKit;

namespace TestProject.IOS
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = " DoneTasks")]
    public partial class DoneListItemView : MvxViewController<DoneListItemViewModel>
    {
        private UIBarButtonItem _btnCAdd;
        private nfloat _cellSpacingHeight = 5;

        public DoneListItemView () : base(nameof(DoneListItemView), null)
        {
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var controller = new UINavigationController();

            _btnCAdd = new UIBarButtonItem(UIBarButtonSystemItem.Add, null);
            NavigationItem.SetRightBarButtonItem(_btnCAdd, false);
            var source = new TasksTableViewSource(DoneTasksTableView);
            //DoneTasksTableView.SectionFooterHeight = _cellSpacingHeight;
            DoneTasksTableView.Source = source;
            var set = this.CreateBindingSet<DoneListItemView, DoneListItemViewModel>();
            set.Bind(source).To(vm => vm.TaskCollection);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.TaskViewCommand);
            set.Bind(_btnCAdd).For("Clicked").To(vm => vm.ShowSecondPageCommand);
            set.Apply();
            DoneTasksTableView.ReloadData();
        }
    }
}