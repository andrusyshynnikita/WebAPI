using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.ViewModels
{
    public class ViewPagerViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public ViewPagerViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ListItemsViewModel = Mvx.IoCConstruct<ListItemsViewModel>();
        }
        public ListItemsViewModel ListItemsViewModel { get; set; }
    }
}
