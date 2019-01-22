using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Interface;
using TestProject.Core.Models;

namespace TestProject.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private IMvxNavigationService _mvxNavigationService;
        ILoginService _loginService;

        public MainViewModel( IMvxNavigationService mvxNavigationService, ILoginService loginService)
        {
            _mvxNavigationService = mvxNavigationService;
            _loginService = loginService;
        }
    }
}
