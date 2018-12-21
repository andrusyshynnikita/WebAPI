using Android.App;
using Android.OS;
using TestProject.Core.ViewModels;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Views;
using Android.Widget;
using TestProject.Core.Models;
using testproject.droid;
using MvvmCross.ViewModels;

namespace TestProject.Droid
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : MvxAppCompatActivity<FirstViewModel>
    {
        Android.Support.V7.Widget.Toolbar mToolbar;
        RecyclerView mRecyclerView;
       
        MvxObservableCollection<TaskInfo> mTaskInfo;
        TasksItemAdapter mAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainLayout);
            mToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Layout.toolbar);
            SetSupportActionBar(mToolbar);
            mTaskInfo = ViewModel.TaskCollection;
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mAdapter = new TasksItemAdapter(mTaskInfo);
            mRecyclerView.SetAdapter(mAdapter);
            //ViewModel.GetTaskInfo.CollectionChanged += GetTaskInfo_CollectionChanged;

        }

        //private void GetTaskInfo_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
            
        //}

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