using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.ViewModels;

namespace TestProject.IOS
{
    [MvxTabPresentation(WrapInNavigationController = true,TabName = " DoneTasks")]
    public partial class DoneListItemView : MvxViewController<DoneListItemViewModel>
    {
        public DoneListItemView () : base(nameof(DoneListItemView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}