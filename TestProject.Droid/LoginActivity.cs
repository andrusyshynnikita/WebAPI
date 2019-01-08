using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Widget;
using Xamarin.Auth;
using System;
using TestProject.Core.Models;
using TestProject.Core.ViewModels;
using System.Linq;
using TestProject.Droid.Helper;

using Newtonsoft.Json;
using System.Json;

namespace TestProject.Droid
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : MvxAppCompatActivity<LoginViewModel>
    {
        private Button _twitter_button;
        private TwitterUser _twitterUser;
        private Button _logout_button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginLayout);
            _twitter_button = FindViewById<Button>(Resource.Id.twitterButton);
            _logout_button = FindViewById<Button>(Resource.Id.LogoutButton);
            _twitter_button.Click += delegate { LoginTwitter(); };
          //  _logout_button.Click += Logout;
        }

        private void LoginTwitter()
        {
            var auth = new OAuth1Authenticator(
                consumerKey: "3xQZI7K71BrOJ7DFVkL1CPTXp",
                consumerSecret: "96oyLeoB5B9YFcJuPw46WYcDGLTR8u31lfH0hOcrhZCETgWaZB",
                requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
                authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
                accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                callbackUrl: new Uri("https://www.google.com")
                );
            auth.AllowCancel = true;
            auth.Completed += twitter_auth_Completed;

            StartActivity(auth.GetUI(this));
            
        }

        async private void twitter_auth_Completed(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {

            if (eventArgs.IsAuthenticated)
            {
                var request = new OAuth1Request("GET",
                    new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"),
                    null,
                    eventArgs.Account);

                var response = await request.GetResponseAsync();

                var json = response.GetResponseText();

                _twitterUser = JsonConvert.DeserializeObject<TwitterUser>(json);

                TwitterUserId.Id_User = _twitterUser.id;
                //StoringDataIntoCache(json);
            }
        }

        //void CachedUserData()
        //{
        //    var cache = AccountStore.Create().FindAccountsForService(Constants.SERVICE_ID).FirstOrDefault();
        //    if (cache != null)
        //    {
        //        Toast.MakeText(this, Constants.HELLO + cache.Properties[Constants.USER_KEY], ToastLength.Long).Show();
        //        _twitter_button.Enabled = false;
        //        _logout_button.Enabled = true;
        //    }
        //    else
        //    {
        //        _twitter_button.Enabled = true;
        //        _logout_button.Enabled = false;
        //    }
        //}

        //void StoringDataIntoCache(string userData)
        //{
        //    var data = JsonValue.Parse(userData);

        //    Account account = new Account();
        //    account.Properties.Add(Constants.USER_KEY, data[Constants.USERNAME]);
        //    AccountStore.Create(this).Save(account, Constants.SERVICE_ID);

        //    Toast.MakeText(this, Constants.WELCOME + data[Constants.USERNAME], ToastLength.Long).Show();
        //    _twitter_button.Enabled = false;
        //    _logout_button.Enabled = true;
        //}

        //void Logout(object sender, EventArgs e)
        //{
        //    var data = AccountStore.Create(this).FindAccountsForService(_twitterUser.id_str).FirstOrDefault();
        //    if (data != null)
        //    {
        //        AccountStore.Create(this).Delete(data, _twitterUser.id_str);

        //        _twitter_button.Enabled = true;
        //        _logout_button.Enabled = false;
        //        Toast.MakeText(this, "You are LoggedOut!!", ToastLength.Short).Show();
        //    }
        //}
    }
}