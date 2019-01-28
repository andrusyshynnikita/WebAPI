using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.Helper;
using TestProject.Core.ViewModels;
using UIKit;
using Xamarin.Auth;

namespace TestProject.IOS.Views
{
    public partial class LoginView : MvxViewController<LoginViewModel>
    {
        public LoginView() : base(nameof(LoginView), null)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            //set.Bind(test).To(vm => vm.ShowDoneList);
            //set.Apply();
        }

        partial void LoginButton_TouchUpInside(UIKit.UIButton sender)
        {
            ViewModel.LoginCommand.Execute(null);
            var ui = ViewModel.Authenticator.GetUI();
            PresentViewController(ui, true, null);
        }


        }


    
}