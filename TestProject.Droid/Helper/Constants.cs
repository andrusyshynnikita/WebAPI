using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestProject.Droid.Helper
{
    public class Constants
    {
        //** For Twitter **//
        public static string TWITTER_KEY = "3xQZI7K71BrOJ7DFVkL1CPTXp";
        public static string TWITTE_SECRET = "96oyLeoB5B9YFcJuPw46WYcDGLTR8u31lfH0hOcrhZCETgWaZB";
        public static string TWITTE_REQ_TOKEN = "https://api.twitter.com/oauth/request_token";
        public static string TWITTER_AUTH = "https://api.twitter.com/oauth/authorize";
        public static string TWITTER_ACCESS_TOKEN = "https://api.twitter.com/oauth/access_token";
        public static string TWITTE_CALLBACKURL = "https://www.google.com";
        public static string TWITTER_REQUESTURL = "https://api.twitter.com/1.1/account/verify_credentials.json";
    }
}