﻿using System;
using Android.App;
using Android.Runtime;
using MvvmCross.Droid.Support.V7.AppCompat;
using TestProject.Core;

namespace TestProject.Droid
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<MvxAppCompatSetup<App>,App>
    {
        public MainApplication()
        {
        }

        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }


}