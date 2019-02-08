using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.ViewModels;
using UIKit;

namespace TestProject.IOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = false, TabName = "About")]
    public partial class AboutView : MvxViewController<AboutViewModel>
    {
        public AboutView() : base(nameof(AboutView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            LogoutBottomConstraint.Constant = TabBarController.TabBar.Frame.Size.Height;
            
            var set = this.CreateBindingSet<AboutView, AboutViewModel>();
            set.Bind(Logout_button).To(vm => vm.LogoutCommand);
            set.Apply();

            UIDevice.Notifications.ObserveOrientationDidChange(OrientationsHandler);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        private void OrientationsHandler(object sender, NSNotificationEventArgs e)
        {
            LogoutBottomConstraint.Constant = TabBarController.TabBar.Frame.Size.Height;
        }
    }
}