using Android.OS;
using Android.Widget;
using System;
using TestProject.Core.Models;
using TestProject.Core.ViewModels;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Runtime;

namespace TestProject.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.login_frame, false)]
    [Register("TestProject.droid.views.LoginView")]
    public class LoginView : BaseFragment<LoginViewModel>
    {
        private Button _twitter_button;
        private TwitterUser _twitterUser;
        private Button _logout_button;
        public Action OnLoggedInHandler;

        protected override int FragmentId => Resource.Layout.LoginLayout;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _twitter_button = view.FindViewById<Button>(Resource.Id.twitterButton);
            _twitter_button.Click += delegate { LoginTwitter(); };
            return view;
        }

        private void LoginTwitter()
        {
            ViewModel.LoginCommand.Execute();
            StartActivity(ViewModel.Authenticator.GetUI(View.Context));
        }
      
    }
}