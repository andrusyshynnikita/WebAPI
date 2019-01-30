using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.ViewModels;

namespace TestProject.IOS
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

            var set = this.CreateBindingSet<AboutView, AboutViewModel>();
            set.Bind(Logout_button).To(vm => vm.LogoutCommand);
            set.Apply();
        }
    }
}