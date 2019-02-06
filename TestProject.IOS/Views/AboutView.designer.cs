// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TestProject.IOS.Views
{
    [Register ("AboutView")]
    partial class AboutView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Logout_button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint LogoutBottomConstraint { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Logout_button != null) {
                Logout_button.Dispose ();
                Logout_button = null;
            }

            if (LogoutBottomConstraint != null) {
                LogoutBottomConstraint.Dispose ();
                LogoutBottomConstraint = null;
            }
        }
    }
}