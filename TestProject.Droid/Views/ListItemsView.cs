using Android.App;
using Android.OS;
using TestProject.Core.ViewModels;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using testproject.droid;

namespace TestProject.Droid
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
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
            _mToolbar = FindViewById<Toolbar>(Resource.Layout.toolbar);
            SetSupportActionBar(_mToolbar);
            _recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);
            _mAdapter = new TasksItemAdapter((IMvxAndroidBindingContext)BindingContext);
            _mAdapter.ItemClick += _mAdapter_ItemClick;
            _recyclerView.Adapter = _mAdapter;
         
        }

        private void _mAdapter_ItemClick(object sender, int e)
        {
            ViewModel.TaskViewCommand.Execute(ViewModel.TaskCollection[e]);
        }
       

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{

        //    MenuInflater.Inflate(Resource.Menu.menu_main, menu);
        //    return base.OnCreateOptionsMenu(menu);
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
        //        ToastLength.Short).Show();
        //    return base.OnOptionsItemSelected(item);
        //}
    }
}