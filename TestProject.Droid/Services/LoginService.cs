//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using MvvmCross;
//using Newtonsoft.Json;
//using TestProject.Core.Interface;
//using TestProject.Core.Models;
//using TestProject.Droid.Helper;
//using Xamarin.Auth;
//using Android.Content;

//namespace TestProject.Droid.Services
//{
//    public class LoginService : ILoginService
//    {
//        private TwitterUser _twitterUser;
//        public Account GetActiveTwitterUser()
//        {
//            var account = AccountStore.Create().FindAccountsForService("Twitter").FirstOrDefault();
//            return account;
//        }

//        public TwitterUser LoginTwitter()
//        {
//            var auth = new OAuth1Authenticator(
//                                Constants.TWITTER_KEY,
//                                Constants.TWITTE_SECRET,
//                                new Uri(Constants.TWITTE_REQ_TOKEN),
//                                new Uri(Constants.TWITTER_AUTH),
//                                new Uri(Constants.TWITTER_ACCESS_TOKEN),
//                                new Uri(Constants.TWITTE_CALLBACKURL));

//            auth.AllowCancel = true;
//            auth.Completed += twitter_auth_Completed;
//            // StartActivity(auth.GetUI(View.Context));
//            auth.GetUI().AddFlags(ActivityFlags.NewTask);
//            Application.StartActivity(auth.GetUI());
//            return _twitterUser;
//        }

//        async private void twitter_auth_Completed(object sender, AuthenticatorCompletedEventArgs eventArgs)
//        {

//            if (eventArgs.IsAuthenticated)
//            {
//                Account loggedInAccount = eventArgs.Account;

//                AccountStore.Create().Save(loggedInAccount, "Twitter");

//                var request = new OAuth1Request("GET",
//                    new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"),
//                    null,
//                    eventArgs.Account);

//                var response = await request.GetResponseAsync();

//                var json = response.GetResponseText();
//                _twitterUser = JsonConvert.DeserializeObject<TwitterUser>(json);
//                var data = AccountStore.Create().FindAccountsForService("Twitter").FirstOrDefault();
//                data.Username = _twitterUser.name;
//                TwitterUserId.Id_User = data.Properties["user_id"];

//                //TwitterUserId.Id_User = _twitterUser.id;
//                //StoringDataIntoCache(_twitterUser);

//            }
//        }
//    }
//}