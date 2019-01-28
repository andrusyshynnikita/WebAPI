using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using TestProject.Core.ViewModels;
using UIKit;

namespace TestProject.IOS.Views
{
    [MvxRootPresentation]
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

            if (_firstTimePresented)
            {
                _firstTimePresented = false;
                ViewModel.ShowDoneListItemViewModelCommand.Execute(null);
                ViewModel.ShowNotDoneListItemViewModelCommand.Execute(null);
                ViewModel.ShowAboutViewModelCommand.Execute(null);
            }
        }
    }
}