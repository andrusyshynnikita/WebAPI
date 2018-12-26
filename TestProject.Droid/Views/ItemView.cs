using Android.App;
using Android.OS;
using TestProject.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace TestProject.Droid.Views
{
    [Activity(Label = "SecondView")]  //,MainLauncher = true)]
    public  class ItemView: MvxAppCompatActivity<ItemViewModel>
    {
        //private Android.Support.V7.Widget.Toolbar _mToolBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ItemLayout);
            //_mToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Layout.toolbar);
            //SetSupportActionBar(_mToolBar);
        }
    }
}