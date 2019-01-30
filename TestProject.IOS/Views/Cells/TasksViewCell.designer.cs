// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TestProject.IOS.Views.Cells
{
    [Register ("TasksViewCell")]
    partial class TasksViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleTask { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TitleTask != null) {
                TitleTask.Dispose ();
                TitleTask = null;
            }
        }
    }
}