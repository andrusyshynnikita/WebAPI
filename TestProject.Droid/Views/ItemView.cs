using Android.App;
using Android.OS;
using TestProject.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Views.InputMethods;
using Android.Widget;
using Android.Graphics;

namespace TestProject.Droid.Views
{
    [Activity(Label = "SecondView")]  
    public  class ItemView: MvxAppCompatActivity<ItemViewModel>
    {
        private Android.Support.V7.Widget.Toolbar _mToolBar;
        private LinearLayout _linearLayout;
        private EditText _editText;




        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ItemLayout);
            _mToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar2);    
            SetSupportActionBar(_mToolBar);
            _linearLayout = FindViewById<LinearLayout>(Resource.Id.item_Layout);
            _linearLayout.Click += delegate { HideSoftKeyboard(); };
            _mToolBar.Click += delegate { HideSoftKeyboard(); };
            _editText = FindViewById<Android.Widget.EditText>(Resource.Id.name_text);
            Typeface type = Typeface.CreateFromAsset(Assets, "13159.otf");
            _editText.SetTypeface(type, TypefaceStyle.Normal);
        }


        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null)
            {
                return;
            }

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }
    }
}