using System;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.Widget;
using TestProject.Core.ViewModels;
using Android.Runtime;
using Android.Support.V4.App;
using Android;
using Android.App;
using System.Threading.Tasks;
using Android.Support.V4.Content;
using Android.Content.PM;
using Android.Util;
using Android.Support.Design.Widget;
using Android.Text;

namespace TestProject.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("TestProject.droid.views.ItemView")]
    public  class ItemView: BaseFragment<ItemViewModel>
    {
        private Android.Support.V7.Widget.Toolbar _mToolBar;
        private LinearLayout _linearLayout;
        private LinearLayout _linearLayout2;
        private EditText _editText;
        private Button _recordingAudio;
        static readonly int REQUEST_STORAGE = 0;
        private View _layout;

        protected override int FragmentId => Resource.Layout.ItemLayout;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            _mToolBar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar2);    
            ParentActivity.SetSupportActionBar(_mToolBar);
            _recordingAudio = view.FindViewById<Button>(Resource.Id.recording);
            _linearLayout = view.FindViewById<LinearLayout>(Resource.Id.item_Layout2);
            _recordingAudio.Click += CheckPermission;
            _linearLayout.Click += delegate { HideSoftKeyboard(); };
            _mToolBar.Click += delegate { HideSoftKeyboard(); };
            _editText = view.FindViewById<Android.Widget.EditText>(Resource.Id.name_text);
            Typeface type = Typeface.CreateFromAsset(Activity.Assets, "13159.otf");
            _editText.SetTypeface(type, TypefaceStyle.Normal);
            return view;
        }

        private void CheckPermission(object sender, EventArgs e)
        {
            if (ActivityCompat.CheckSelfPermission(Context, Manifest.Permission.RecordAudio) == (int)Permission.Granted)
            {
                ViewModel.StartRecordingCommand.Execute();
            }

            else
            {
                RequestStoragePermission();
            }
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            HideSoftKeyboard();
        }

        public void HideSoftKeyboard()
        {
            InputMethodManager close = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            close.HideSoftInputFromWindow(_linearLayout.WindowToken, 0);
        }


        void RequestStoragePermission()
        {
            //Log.Info("TaskDropper", "Microphone permission has NOT been granted. Requesting permission.");

            //if (ActivityCompat.ShouldShowRequestPermissionRationale(ParentActivity, Manifest.Permission.WriteExternalStorage))
            //{
            //    Log.Info("TaskDropper", "Displaying storage permission rationale to provide additional context.");

            //    //Snackbar.Make(_layout, "Storage Permission",
            //    //     Snackbar.LengthIndefinite).SetAction(Resource.String.ok, new Action<View>(delegate (View obj) {
            //    //         ActivityCompat.RequestPermissions(ParentActivity, new String[] { Manifest.Permission.WriteExternalStorage }, REQUEST_STORAGE);
            //    //     })).Show();
            //}
           // else
          //  {
                // Microphone permission has not been granted yet. Request it directly.
                ActivityCompat.RequestPermissions(ParentActivity, new String[] { Manifest.Permission.RecordAudio }, REQUEST_STORAGE);
          //  }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {

            if (requestCode == REQUEST_STORAGE)
            {
                // Received permission result for camera permission.
                Log.Info("TaskDropper", "Received response for Microphone  permission request.");

                // Check if the only required permission has been granted
                if (grantResults.Length == 1 && grantResults[0] == Permission.Granted)
                {
                    // Microphone permission has been granted, preview can be displayed
                    Log.Info("TaskDropper", "Microphone permission has now been granted. Showing preview.");
                    Snackbar.Make(_layout, Resource.String.permission_available_microphone, Snackbar.LengthShort).Show();
                }
                else
                {
                    Log.Info("TaskDropper", "Microphone permission was NOT granted.");
                    Snackbar.Make(_layout, Resource.String.permissions_not_granted, Snackbar.LengthShort).Show();
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

    }
}