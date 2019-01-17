using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Core.ViewModels
{
    public class AboutViewModel : MvxViewModel
    {
        public AboutViewModel()
        {
        }

        public IMvxCommand LogoutCommand => new MvxCommand(LogOut);

        private void LogOut()
        {
            OnLoggedInHandler();
        }
        public Action OnLoggedInHandler
        {
            get; set;
        }
    }
}
