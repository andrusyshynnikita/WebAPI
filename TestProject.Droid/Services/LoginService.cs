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
using TestProject.Core.Interface;
using TestProject.Droid.Helper;
using Xamarin.Auth;

namespace TestProject.Droid.Services
{
    class LoginService : ILoginService
    {
        public Account GetActiveTwitterUser()
        {
            var account = AccountStore.Create().FindAccountsForService("Twitter").FirstOrDefault();
            return account;
        }
    }
}