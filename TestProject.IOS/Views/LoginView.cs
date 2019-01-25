using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.ViewModels;
using UIKit;

namespace TestProject.IOS
{
    public partial class LoginView : MvxViewController<LoginViewModel>
    {
        public LoginView() : base(nameof(LoginView), null)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            test.TouchUpInside += (object sender, EventArgs e) =>
            {
                ViewModel.LoginCommand.Execute(null);
                var ui = ViewModel.Authenticator.GetUI();
                PresentViewController(ui, true, null);
            };
            //var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            //set.Bind(test).To(vm => vm.ShowDoneList);
            //set.Apply();
        }

        //private void LoginButton_TouchUpInside(object sender, System.EventArgs e)
        //{
        //    ViewModel.LoginCommand.Execute(null);
        //    var ui = ViewModel.Authenticator.GetUI();
        //    PresentViewController(ui, true, null);
        //}
    }
}