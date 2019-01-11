using System.Collections.Generic;
using Android.OS;
using Android.App;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using TaskDropper.Droid.ViewAdapters;
using TestProject.Core.ViewModels;

namespace TestProject.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("TestProject.droid.views.ViewPagerView")]
    public class ViewPagerView : BaseFragment<ViewPagerViewModel>
    {
        private ViewPager _viewPager;
       // private TitlePageIndicator _indicator;

        protected override int FragmentId => Resource.Layout.ViewPager;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager1);
            var fragments = new List<MvxViewPagerFragmentAdapter.FragmentInfo>
            {
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                    FragmentType = typeof(ListItemsView),
                    Title="TaskyDrop",
                    ViewModel= ViewModel.ListItemsViewModel
                }
            };
            _viewPager.Adapter = new MvxViewPagerFragmentAdapter(Activity, ChildFragmentManager, fragments);
            var tabLayout = view.FindViewById<TableLayout>(Resource.Id.tabs);
           // tabLayout.SetupWithViewPager(_viewPager);
            return view;
        }
    }
}