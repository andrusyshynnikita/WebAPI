using System;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using TestProject.Core.ViewModels;

namespace TestProject.IOS.Views
{
    [MvxRootPresentation(WrapInNavigationController =false)]
    public class TabBarView : MvxTabBarViewController<ViewPagerViewModel>
    {
        private bool _firstTimePresented = true;

        public TabBarView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var logOutHandler = new Action(() => ViewModel.LogoutCommand.Execute());

            if (_firstTimePresented)
            {
                _firstTimePresented = false;
                ViewModel.ShowDoneListItemViewModelCommand.Execute(logOutHandler);
                ViewModel.ShowNotDoneListItemViewModelCommand.Execute(logOutHandler);
                ViewModel.ShowAboutViewModelCommand.Execute(logOutHandler);
            }
        }
    }
}