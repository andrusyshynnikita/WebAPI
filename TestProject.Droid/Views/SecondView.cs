using Android.App;
using Android.OS;
using TestProject.Core.ViewModels;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace TestProject.Droid.Views
{
    [Activity(Label = "SecondView", MainLauncher = true)]
    public  class SecondView: MvxAppCompatActivity<SecondViewModel>
    {
        private Android.Support.V7.Widget.Toolbar _mToolBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SecondPageLayout);
            _mToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Layout.toolbar);
            SetSupportActionBar(_mToolBar);
        }
    }
}