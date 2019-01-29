using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using TestProject.Core.ViewModels;

namespace TestProject.IOS
{
    public partial class ItemView : MvxViewController<ItemViewModel>
    {
        public ItemView () :  base(nameof(ItemView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ItemView, ItemViewModel>();
            set.Bind(Title_text).To(vm => vm.Title);
            set.Bind(Description_text).To(vm => vm.Description);
            set.Bind(Status_switch).To(vm => vm.Status);
            set.Bind(Save_button).To(vm => vm.SaveCommand);
            set.Bind(Delete_button).To(vm => vm.DeleteCommand);
            set.Apply();

        }
    }
}