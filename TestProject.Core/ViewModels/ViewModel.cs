using System;
using System.Threading.Tasks;
using System.Text;
using MvvmCross.ViewModels;

namespace TestProject.Core.ViewModels
{
    public class ViewModel : MvxViewModel
    {
        public override async Task Initialize()
        {
            await base.Initialize();
        }
    }
}
