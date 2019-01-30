using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using TestProject.Core.ViewModels;
using UIKit;

namespace TestProject.IOS
{
   // [MvxChildPresentation]
    public partial class ItemView : MvxViewController<ItemViewModel>
    {
        private UIBarButtonItem _btnCBack;

        public ItemView () :  base(nameof(ItemView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _btnCBack = new UIBarButtonItem(UIBarButtonSystemItem.Reply, null);
            NavigationItem.SetLeftBarButtonItem(_btnCBack, false);

            var set = this.CreateBindingSet<ItemView, ItemViewModel>();
            set.Bind(Title_text).To(vm => vm.Title);
            set.Bind(Description_text).To(vm => vm.Description);
            set.Bind(Status_switch).To(vm => vm.Status);
            set.Bind(Save_button).To(vm => vm.SaveCommand);
            set.Bind(Delete_button).To(vm => vm.DeleteCommand);
            set.Bind(_btnCBack).For("Clicked").To(vm => vm.CloseCommand);
            set.Apply();

        }
    }
}