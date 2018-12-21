using Android.App;
using Android.OS;
using TestProject.Core.ViewModels;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Views;
using Android.Widget;
using TestProject.Core.Models;
using MvvmCross.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.Views;
using testproject.droid;

namespace TestProject.Droid
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : MvxAppCompatActivity<FirstViewModel>
    {
        Android.Support.V7.Widget.Toolbar mToolbar;

        
        private RecyclerView.LayoutManager _layoutManager;
        private TasksItemAdapter _mAdapter;
        private MvxRecyclerView _recyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainLayout);
            mToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Layout.toolbar);
            SetSupportActionBar(mToolbar);

            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);
            var recyclerAdapter = new TasksItemAdapter((IMvxAndroidBindingContext)this.BindingContext);
            _recyclerView.Adapter = recyclerAdapter;
            //ViewModel.GetTaskInfo.CollectionChanged += GetTaskInfo_CollectionChanged;

        }

        //private void GetTaskInfo_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{

        //}
        
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}