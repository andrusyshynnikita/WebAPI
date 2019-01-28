using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.ViewModels;

namespace TestProject.IOS
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "NotDoneTasks")]
    public partial class NotDoneListItemView : MvxViewController<NotDoneListItemViewModel>
    {
        public NotDoneListItemView() : base(nameof(NotDoneListItemView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}