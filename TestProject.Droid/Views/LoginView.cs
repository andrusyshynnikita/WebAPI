using Android.App;
using Android.OS;
using Android.Widget;
using Xamarin.Auth;
using System;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using TestProject.Core.Models;
using System.Linq;
using Newtonsoft.Json;
using TestProject.Droid.Helper;
using TestProject.Core.ViewModels;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Runtime;
using TestProject.Droid.Views;

namespace TestProject.Droid
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
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
            _logout_button = view.FindViewById<Button>(Resource.Id.LogoutButton);
            CachedUserData();
            _twitter_button.Click += delegate { LoginTwitter(); };
            _logout_button.Click += Logout;
            return view;
        }

        private void LoginTwitter()
        {
            var auth = new OAuth1Authenticator(
                                Constants.TWITTER_KEY,
                                Constants.TWITTE_SECRET,
                                new Uri(Constants.TWITTE_REQ_TOKEN),
                                new Uri(Constants.TWITTER_AUTH),
                                new Uri(Constants.TWITTER_ACCESS_TOKEN),
                                new Uri(Constants.TWITTE_CALLBACKURL));

            auth.AllowCancel = true;
            auth.Completed += twitter_auth_Completed;
            StartActivity(auth.GetUI(View.Context));
        }

        async private void twitter_auth_Completed(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {

            if (eventArgs.IsAuthenticated)
            {
                Account loggedInAccount = eventArgs.Account;

                AccountStore.Create(View.Context).Save(loggedInAccount, "Twitter");

                var request = new OAuth1Request("GET",
                    new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"),
                    null,
                    eventArgs.Account);

                var response = await request.GetResponseAsync();

                var json = response.GetResponseText();

                _twitterUser = JsonConvert.DeserializeObject<TwitterUser>(json);
                var data = AccountStore.Create(View.Context).FindAccountsForService("Twitter").FirstOrDefault();
                data.Username = _twitterUser.name;
                TwitterUserId.Id_User= data.Properties["user_id"];
                  _twitter_button.Enabled = false;
                  _logout_button.Enabled = true;
                
                //TwitterUserId.Id_User = _twitterUser.id;
                // StoringDataIntoCache(_twitterUser);

            }
        }

        void CachedUserData()
        {
            var cache = AccountStore.Create().FindAccountsForService("Twitter").FirstOrDefault();
            if (cache != null)
            {
                //Toast.MakeText(this, Constants.HELLO + cache.Properties[Constants.USER_KEY], ToastLength.Long).Show();
                _twitter_button.Enabled = false;
                _logout_button.Enabled = true;
                TwitterUserId.Id_User = cache.Properties["user_id"];
            }
            else
            {
                _twitter_button.Enabled = true;
                _logout_button.Enabled = false;
            }
        }

        //void StoringDataIntoCache(TwitterUser userData)
        //{
        //    //var data = JsonValue.Parse(userData);

        //    Account account = new Account();
        //    account.Properties.Add(Constants.USER_KEY, userData.id_str);
        //    AccountStore.Create(this).Save(account, Constants.SERVICE_ID);
        //    //Toast.MakeText(this, Constants.WELCOME + data[Constants.USERNAME], ToastLength.Long).Show();
        //    _twitter_button.Enabled = false;
        //    _logout_button.Enabled = true;
        //}

        void Logout(object sender, EventArgs e)
        {
            var data = AccountStore.Create(View.Context).FindAccountsForService("Twitter").FirstOrDefault();
            //var d= data.Properties["user_id"];
            if (data != null)
            {
                AccountStore.Create(View.Context).Delete(data, "Twitter");
                TwitterUserId.Id_User = null;
                _twitter_button.Enabled = true;
                _logout_button.Enabled = false;
                Toast.MakeText(View.Context, "You are LoggedOut!!", ToastLength.Short).Show();
            }
        }
    }
}