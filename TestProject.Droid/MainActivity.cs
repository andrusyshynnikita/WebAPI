using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TestProject.Core.ViewModels;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.V7.AppCompat;
using Android.Views;
using Android.Widget;

namespace TestProject.Droid
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : MvxAppCompatActivity<FirstViewModel>
    {
        Android.Support.V7.Widget.Toolbar mToolbar;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainLayout);

            mToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Layout.toolbar);

            SetSupportActionBar(mToolbar);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }



    }

}