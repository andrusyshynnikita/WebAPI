﻿using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using TestProject.Droid.ViewAdapters;
using TestProject.Core.ViewModels;

namespace TestProject.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, false)]
    [Register("TestProject.droid.views.ViewPagerView")]
    public class ViewPagerView : BaseFragment<ViewPagerViewModel>
    {
        private ViewPager _viewPager;

        protected override int FragmentId => Resource.Layout.ViewPager;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager1);
            var fragments = new List<MvxViewPagerFragmentAdapter.FragmentInfo>
            {
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                    FragmentType = typeof(DoneListItemView),
                    Title="Done Tasks",
                    ViewModel= ViewModel.DoneListItemViewModel
                },
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                    FragmentType = typeof(NotDoneListItemView),
                    Title="Not Done Tasks",
                    ViewModel= ViewModel.NotDoneListItemViewModel
                },
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                    FragmentType = typeof(AboutView),
                    Title = "About",
                    ViewModel= ViewModel.AboutViewModel
                }
            };
            _viewPager.Adapter = new MvxViewPagerFragmentAdapter(Activity, ChildFragmentManager, fragments);

            var tabLayout = view.FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(_viewPager);

            return view;
        }
    }
}