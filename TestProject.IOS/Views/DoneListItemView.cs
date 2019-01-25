using Foundation;
using MvvmCross.Platforms.Ios.Views;
using System;
using TestProject.Core.ViewModels;

namespace TestProject.IOS
{
    public partial class DoneListItemView : MvxViewController<DoneListItemViewModel>
    {
        public DoneListItemView() : base(nameof(DoneListItemView), null)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        private void LoginButton_TouchUpInside(object sender, System.EventArgs e)
        {

        }
    }
}