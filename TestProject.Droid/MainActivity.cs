using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Platforms.Android.Views;
using SQLite;
using System;
using System.IO;
using TestProject.Core.ViewModels;
using Android.Views;

namespace TestProject.Droid
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : MvxActivity<ViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainLayout);
            
           




        }


       
    }
}