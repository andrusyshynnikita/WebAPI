using Android.App;
using Android.OS;
using TestProject.Core.ViewModels;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using testproject.droid;
using Android.Graphics;
using Xamarin.Auth;
using System;

namespace TestProject.Droid
{
    [Activity(Label = "MainActivity")]//, MainLauncher = true)]
    public class ListItemsView : MvxAppCompatActivity<ListItemsViewModel>
    {
        private Toolbar _mToolbar;
        private RecyclerView.LayoutManager _layoutManager;
        private TasksItemAdapter _mAdapter;
        private MvxRecyclerView _recyclerView;
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListItemsLayout);
            _mToolbar = FindViewById<Toolbar>(Resource.Id.toolbar1);
            SetSupportActionBar(_mToolbar);
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);
            _mAdapter = new TasksItemAdapter((IMvxAndroidBindingContext)BindingContext);
            _recyclerView.Adapter = _mAdapter;

        }

        
    }
}