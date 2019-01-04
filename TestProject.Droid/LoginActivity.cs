using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Widget;
using Xamarin.Auth;
using System;
using Java.Net;
using Authenticator = Xamarin.Auth.Authenticator;
using Newtonsoft.Json;
using TestProject.Core.Models;
using TestProject.Core.ViewModels;

namespace TestProject.Droid
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : MvxAppCompatActivity<LoginViewModel>
    {
        private Button _twitter_button;
        private TwitterUser _twitterUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginLayout);
            _twitter_button = FindViewById<Button>(Resource.Id.twitterButton);
            _twitter_button.Click += delegate { LoginTwitter(); };
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

                var twitteruser = JsonConvert.DeserializeObject<TwitterUser>(json);

                TwitterUserId.Id_User = twitteruser.id;

            }
        }


    }
}