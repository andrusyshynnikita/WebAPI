using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using TestProject.Core.ViewModels;
using UIKit;

namespace TestProject.IOS.Views
{
    [MvxModalPresentation(WrapInNavigationController = true, ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal)]
    public partial class ItemView : MvxViewController<ItemViewModel>
    {
        private UIBarButtonItem _btnBack;

        public ItemView() : base(nameof(ItemView), null)
        {
        }

        public override void ViewDidLoad()
        {

            base.ViewDidLoad();

            Title = "TaskyDrop";

            //MainUIView.InsetsLayoutMarginsFromSafeArea = true;

            NavigationController.Toolbar.BackgroundColor = UIColor.Blue;
            NavigationController.NavigationBar.BarTintColor = UIColor.Purple;
            NavigationController.NavigationBar.TintColor = UIColor.Black;
            _btnBack = new UIBarButtonItem(UIBarButtonSystemItem.Reply, null);
            NavigationItem.SetLeftBarButtonItem(_btnBack, false);
            var set = this.CreateBindingSet<ItemView, ItemViewModel>();
            set.Bind(Title_text).To(vm => vm.Title);
            set.Bind(Title_text).For(v => v.Enabled).To(vm => vm.IsTitleEnable);
            set.Bind(Description_text).To(vm => vm.Description);
            set.Bind(Status_switch1).To(vm => vm.Status);
            set.Bind(Save_button).To(vm => vm.SaveCommand);
            set.Bind(Save_button).For(v => v.Enabled).To(vm => vm.IsSavingTaskEnable);
            set.Bind(Delete_button).To(vm => vm.DeleteCommand);
            set.Bind(Delete_button).For(v => v.Enabled).To(vm => vm.IsDeletingTaskEnable);
            set.Bind(_btnBack).For("Clicked").To(vm => vm.CloseCommand);
            set.Bind(recording).To(vm => vm.StartRecordingCommand);
            set.Bind(recording).For(v => v.BackgroundColor).To(vm => vm.IsREcordChecking).WithConversion("Color");
            set.Bind(recording).For("Title").To(vm => vm.IsREcordChecking).WithConversion("RecordingButton");
            set.Bind(Play).To(vm => vm.PlayRecordingCommand);
            set.Bind(Play).For(v => v.Enabled).To(vm => vm.IsPlayRecordingEnable);
            set.Bind(Play).For(v => v.BackgroundColor).To(vm => vm.IsPlayChecking).WithConversion("Color");
            set.Bind(Play).For("Title").To(vm => vm.IsPlayChecking).WithConversion("PlayingButton");
            set.Apply();

            this.Title_text.ShouldReturn += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;

            };

            this.Description_text.ShouldEndEditing += (textField) =>
            {
                textField.ResignFirstResponder();
                return true;
            };

            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            View.AddGestureRecognizer(g);
        }
       
    }
}