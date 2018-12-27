using Android.App;
using Android.OS;
using TestProject.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace TestProject.Droid.Views
{
    [Activity(Label = "SecondView")]  
    public  class ItemView: MvxAppCompatActivity<ItemViewModel>
    {
      
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ItemLayout);
            
        }
    }
}